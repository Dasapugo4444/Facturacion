using MongoDB.Driver;

namespace Facturación.Connections
{
    public class Repository
    {
        private MongoClient client = new MongoClient();
        public void Connect ()
        {
            IMongoDatabase facturacion = client.GetDatabase("facturacion");
        }

    }
}