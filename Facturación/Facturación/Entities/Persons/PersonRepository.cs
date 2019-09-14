using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Facturación.Entities.Persons
{
    public class PersonRepository
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Person> collection;

        public PersonRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("facturacion");
            collection = database.GetCollection<Person>("persons");
        }

        public void Insert(Person person)
        {
            collection.InsertOne(person);
        }

        public void Update(ObjectId id, BsonDocument doc)
        {
            var filter = Builders<Person>.Filter.Eq("_id", id);
            var item = Builders<Person>.Update
                .Set("PersonType", doc.GetValue("personType"))
                .Set("FirstName", doc.GetValue("firstName"))
                .Set("SurName", doc.GetValue("surName"))
                .Set("DocumentType", doc.GetValue("identificationType"))
                .Set("IdentificationNumber", doc.GetValue("identificationNumber"))
                .Set("Phone", doc.GetValue("phone"));
            collection.FindOneAndUpdate(filter, item);
        }

        public void Delete(ObjectId id)
        {
            collection.FindOneAndDelete(Builders<Person>.Filter.Eq("_id", id));
        }
        public List<Person> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        public Person Get(ObjectId id)
        {
            return collection.Find<Person>(p => p.Id == id).FirstOrDefault();
        }
    }
}
