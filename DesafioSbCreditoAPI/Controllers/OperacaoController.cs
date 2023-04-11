using DesafioSbCreditoAPI.Domain.Models;
using DesafioSbCreditoAPI.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioSbCreditoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacaoController : ControllerBase
    {

        private readonly IOperacaoService _operacaoService;

        public OperacaoController(IOperacaoService operacaoService)
        {
            _operacaoService = operacaoService;
        }

        // GET: api/<OperacaoController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Operacao>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var operacoes = await _operacaoService.ListarOperacoes();
            return Ok(operacoes);
        }

        // GET api/<OperacaoController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Operacao), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string id)
        {

            var operacao = await _operacaoService.ListarOperacaoPorId(id);

            if(operacao == null) return NotFound(operacao);
            
            return Ok(operacao);
            
        }

        // POST api/<OperacaoController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Operacao novaOperacao)
        {
            var codigoOperacao = await _operacaoService.CadastrarOperacao(novaOperacao);

            if(codigoOperacao == "Erro")
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.Content = new StringContent($"Erro ao Cadastrar a Operação");
                return ((IActionResult)responseMessage);

            }

            return Created(Request.Path + $"/{codigoOperacao}" ,codigoOperacao);
                        
        }

        // PUT api/<OperacaoController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Operacao operacaoAtualizada)
        {

            var localizaOperacao = await _operacaoService.ListarOperacaoPorId(operacaoAtualizada.Id);

            if(localizaOperacao == null)
            {

                return NotFound($"Operacao ({operacaoAtualizada.Id}) não existe.");
            }

            var retAtualizacao = await _operacaoService.AtualizarOperacao(operacaoAtualizada);

            if(retAtualizacao == "Erro")
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.Content = new StringContent($"Erro ao Atualizar a Operação {operacaoAtualizada.Id}");
                return ((IActionResult)responseMessage);
            }

            return Ok(retAtualizacao);

        }

        // DELETE api/<OperacaoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {

            var localizaOperacao = await _operacaoService.ListarOperacaoPorId(id);

            if (localizaOperacao == null)
            {
                return NotFound($"Operacao ({id}) não existe.");
            }

            var retApagar = await _operacaoService.ApagarOperacao(id);

            if (retApagar == "Erro")
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.Content = new StringContent("Erro ao Apagar Operação");
                return ((IActionResult)responseMessage);
            }

            return NoContent();

        }
    }
}
