
namespace DesafioSbCreditoAPI.Domain.Models;

public class Operacao : MongoDbDocumentBase
{

    public DateTime dataCadastro { get; set; }
    public IEnumerable<Titulo>? titulos { get; set; }
    public string? usuarioCadastro { get; set; }
}
