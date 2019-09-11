using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Facturación.Entities.PersonTypes
{
    public class PersonTypeRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<PersonType> collection;

        public PersonTypeRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("facturacion");
            collection = database.GetCollection<PersonType>("personTypes");
        }
        public void Insert(PersonType documentType)
        {
            collection.InsertOne(documentType);
        }
        public void Update(ObjectId id, BsonDocument newDocument)
        {
            var filter = Builders<PersonType>.Filter.Eq("_id", id);
            var item = Builders<PersonType>.Update.Set("Code", newDocument.GetValue("code")).Set("Name", newDocument.GetValue("name"));
            var update = collection.FindOneAndUpdate(filter, item);
        }
        public void Delete(ObjectId id)
        {
            collection.FindOneAndDelete(Builders<PersonType>.Filter.Eq("_id", id));
        }
        public List<PersonType> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }
        public PersonType Get(ObjectId id)
        {
            return collection.Find<PersonType>(pt => pt.Id == id).FirstOrDefault();
        }
    }
}