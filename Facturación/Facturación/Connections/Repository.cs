using MongoDB.Bson;
using MongoDB.Driver;

namespace Facturación.Connections
{
    public class Repository<TEntity>
    {
        public MongoClient client;
        public IMongoDatabase db;
        public void Connect (string collection)
        {
            client = new MongoClient();
            db = client.GetDatabase(collection);
        }

    }
}