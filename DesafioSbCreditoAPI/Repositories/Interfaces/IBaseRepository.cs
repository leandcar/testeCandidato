namespace DesafioSbCreditoAPI.Repositories.Interfaces;

public interface IBaseRepository<TDocument> where TDocument : class
{


    public Task<string> Adicionar(TDocument document);
    public Task<string> Apagar(string id);
    public Task<string> Atualizar(TDocument document);
    public Task<TDocument> ListarPorId(string id);
    public Task<IEnumerable<TDocument>> ListarTodos();
    
    
    

}
