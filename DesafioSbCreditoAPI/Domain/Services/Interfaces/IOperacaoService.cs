using DesafioSbCreditoAPI.Domain.Models;

namespace DesafioSbCreditoAPI.Domain.Services.Interfaces;

public interface IOperacaoService
{

    Task<IEnumerable<Operacao>> ListarOperacoes();
    Task<Operacao> ListarOperacaoPorId(string idOperacao);
    Task<string> CadastrarOperacao(Operacao novaOperacao);
    Task<string> AtualizarOperacao(Operacao operacao);
    Task<string> ApagarOperacao(string idOperacao);

}
