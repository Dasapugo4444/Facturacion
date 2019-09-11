using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturación.Entities.Taxes
{
    public class TaxRepository
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Tax> collection;

        public TaxRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("facturacion");
            collection = database.GetCollection<Tax>("taxes");
        }

        public void Insert(Tax taxes)
        {
            collection.InsertOne(taxes);
        }

        public void Update(ObjectId id, BsonDocument doc)
        {
            var filter = Builders<Tax>.Filter.Eq("_id", id);
            var item = Builders<Tax>.Update.Set("Code", doc.GetValue("code")).Set("Name", doc.GetValue("name")).Set("Percentage", doc.GetValue("percentage"));
            collection.FindOneAndUpdate(filter, item);
        }

        public void Delete(ObjectId id)
        {
            collection.FindOneAndDelete(Builders<Tax>.Filter.Eq("_id", id));
        }
        public List<Tax> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        public Tax Get(ObjectId id)
        {
            return collection.Find<Tax>(t => t.Id == id).FirstOrDefault();
        }
    }
}