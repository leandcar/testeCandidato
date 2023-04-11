using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DesafioSbCreditoAPI.Domain.Models
{
    /// <summary>
    /// Classes que herdarem de MongoDbDocumentBase serão validas em MongoDbService
    /// </summary>
    public abstract class MongoDbDocumentBase
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }


    }
}
