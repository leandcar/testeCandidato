using DesafioSbCreditoAPI.Domain.Models;
using DesafioSbCreditoAPI.Domain.Services.Interfaces;
using DesafioSbCreditoAPI.Repositories.Interfaces;

namespace DesafioSbCreditoAPI.Domain.Services;

public class OperacaoService : IOperacaoService
{

    private readonly IOperacaoRepository _opercaoRepository;

    public OperacaoService(IOperacaoRepository opercaoRepository)
    {
        _opercaoRepository = opercaoRepository;
    }

    public async Task<string> ApagarOperacao(string idOperacao)
    {
        var retorno = await _opercaoRepository.Apagar(idOperacao);
        return retorno;
    }

    public async Task<string> AtualizarOperacao(Operacao operacao)
    {
        var retorno = await _opercaoRepository.Atualizar(operacao);
        return retorno;
    }

    public async Task<string> CadastrarOperacao(Operacao novaOperacao)
    {
        var retorno = await _opercaoRepository.Adicionar(novaOperacao);
        return retorno;
    }

    public async Task<Operacao> ListarOperacaoPorId(string idOperacao)
    {
        return await _opercaoRepository.ListarPorId(idOperacao);
    }

    public async Task<IEnumerable<Operacao>> ListarOperacoes()
    {
        return await _opercaoRepository.ListarTodos();
    }
}
