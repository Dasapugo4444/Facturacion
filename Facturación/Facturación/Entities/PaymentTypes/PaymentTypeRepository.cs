using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Facturación.Entities.PaymentTypes
{
    public class PaymentTypeRepository
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<PaymentType> collection;

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

        public void Update(ObjectId id, BsonDocument doc)
        {
            var filter = Builders<PaymentType>.Filter.Eq("_id", id);
            var item = Builders<PaymentType>.Update.Set("Code", doc.GetValue("code")).Set("Name", doc.GetValue("name"));
            collection.FindOneAndUpdate(filter, item);
        }

        public void Delete(ObjectId id)
        {
            collection.FindOneAndDelete(Builders<PaymentType>.Filter.Eq("_id", id));
        }

        public List<PaymentType> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        public PaymentType Get(ObjectId id)
        {
            return collection.Find<PaymentType>(pt => pt.Id == id).FirstOrDefault();
        }
    }
}