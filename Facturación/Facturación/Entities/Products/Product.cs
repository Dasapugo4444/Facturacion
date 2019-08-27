using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Facturación.Entities.Products
{
    public sealed class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }
        [BsonElement("Price")]
        public float Price { get; set; }
        [BsonElement("Stock")]
        public int Stock { get; set; }
        [BsonElement("Tax")]
        public Taxes.Tax Tax { get; set; }
    }
}