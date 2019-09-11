using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Facturación.Entities.ProductCategories
{
    public class Category
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Code")]
        public string Code { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}