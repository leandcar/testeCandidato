using DesafioSbCreditoAPI.Domain.Models;
using DesafioSbCreditoAPI.Infra.Data;
using DesafioSbCreditoAPI.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using System.Diagnostics.CodeAnalysis;

namespace DesafioSbCreditoAPI.Repositories
{
    public class BaseRepository<TDocument> : IBaseRepository<TDocument> where TDocument : MongoDbDocumentBase
    {

        protected MongoDbService<TDocument> _dbService;

        public BaseRepository(IOptions<MongoDbConfig> options, string collectionName)
        {
            _dbService = new MongoDbService<TDocument>(options, collectionName);
        }

        public async Task<string> Adicionar(TDocument document)
        {
            try
            {

                document.Id = ObjectId.GenerateNewId().ToString();

                _dbService.CreateAsync(document).Wait();

                return document.Id;
            }
            catch (Exception)
            {
                return "Erro";
            }
            
        }

        public async Task<string> Apagar(string id)
        {
            try
            {
                _dbService.RemoveAsync(id).Wait();
                return "Sucesso";
            }
            catch (Exception)
            {

                return "Erro";
            }

        }

        public async Task<string> Atualizar(TDocument document)
        {
            try
            {

                _dbService.RemoveAsync(document.Id ?? "0").Wait();

                _dbService.CreateAsync(document).Wait();

                return "Sucesso";

            }
            catch (Exception)
            {

                return "Erro";
            }
        }

        public async Task<TDocument> ListarPorId(string id)
        {
            return await _dbService.GetAsync(id);
        }

        public async Task<IEnumerable<TDocument>> ListarTodos()
        {
            return await _dbService.GetAllAsync();
        }
    }
}
