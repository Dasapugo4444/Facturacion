using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Facturación.Entities.PaymentTypes
{
    public class PaymentTypeRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<PaymentType> collection;

        public PaymentTypeRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("facturacion");
            collection = database.GetCollection<PaymentType>("paymentTypes");
        }

        public void Insert(PaymentType paymentType)
        {
            collection.InsertOne(paymentType);
        }

        public List<PaymentType> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}