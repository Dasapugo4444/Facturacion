using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Facturación.Entities.Persons
{
    public class PersonRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Person> collection;

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

        public List<Person> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
