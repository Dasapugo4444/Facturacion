using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Facturación.Entities.DocumentTypes
{
    public class DocumentTypeRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<DocumentType> collection;

        public DocumentTypeRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("facturacion");
            collection = database.GetCollection<DocumentType>("documentTypes");
        }

        public void Insert(DocumentType documentType)
        {
            collection.InsertOne(documentType);
        }

        public List<DocumentType> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}