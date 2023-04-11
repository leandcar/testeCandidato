using DesafioSbCreditoAPI.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DesafioSbCreditoAPI.Infra.Data;

public class MongoDbService<TDocument> where TDocument : MongoDbDocumentBase
{

    private readonly IMongoCollection<TDocument> _collection;

	public MongoDbService(IOptions<MongoDbConfig> optionsConfig, string collectionName)
	{
        var mongoClient = new MongoClient(
            optionsConfig.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            optionsConfig.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<TDocument>(
            collectionName);

    }


    public async Task<List<TDocument>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<TDocument?> GetAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(TDocument newDocument) =>
        await _collection.InsertOneAsync(newDocument);

    public async Task UpdateAsync(string id, TDocument updatedDocument) =>
        await _collection.ReplaceOneAsync(x => x.Id == id, updatedDocument);

    public async Task RemoveAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);




}
