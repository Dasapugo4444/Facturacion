using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturación.Entities.Products
{
    public class ProductRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Product> collection;

        public ProductRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("facturacion");
            collection = database.GetCollection<Product>("products");
        }

        public void Insert(Product product)
        {
            collection.InsertOne(product);
        }

        public void Update(ObjectId id, BsonDocument doc)
        {
            var filter = Builders<Product>.Filter.Eq("_id", id);
            var item = Builders<Product>.Update
                .Set("Name", doc.GetValue("name"))
                .Set("Category", doc.GetValue("category"))
                .Set("Price", doc.GetValue("price"))
                .Set("Stock", doc.GetValue("stock"))
                .Set("Price", doc.GetValue("price"))
                .Set("Stock", doc.GetValue("stock"));
            collection.FindOneAndUpdate(filter, item);
        }

        public void Delete(ObjectId id)
        {
            collection.FindOneAndDelete(Builders<Product>.Filter.Eq("_id", id);
        }
        public List<Product> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        public Product Get(ObjectId id)
        {
           return collection.Find<Product>(p => p.Id == id).FirstOrDefault();
        }
    }
}