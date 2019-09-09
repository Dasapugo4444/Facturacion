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
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Tax> collection;

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

        public List<Tax> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}