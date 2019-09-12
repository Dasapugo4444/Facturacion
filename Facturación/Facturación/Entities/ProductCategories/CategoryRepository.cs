using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturación.Entities.ProductCategories
{
    public class CategoryRepository
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Category> collection;

        public CategoryRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("facturacion");
            collection = database.GetCollection<Category>("categories");
        }

        public void Insert(Category Category)
        {
            collection.InsertOne(Category);
        }
        public void Update(ObjectId id, BsonDocument doc)
        {
            var filter = Builders<Category>.Filter.Eq("_id", id);
            var item = Builders<Category>.Update.Set("Code", doc.GetValue("code")).Set("Name", doc.GetValue("name"));
            collection.FindOneAndUpdate(filter, item);
        }
        public void Delete(ObjectId id)
        {
            collection.FindOneAndDelete(Builders<Category>.Filter.Eq("_id", id));
        }
        public List<Category> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }
        public Category Get(ObjectId id)
        {
            return collection.Find<Category>(dt => dt.Id == id).FirstOrDefault();
        }
    }
}
