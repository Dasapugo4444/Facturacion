using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Facturación.Entities.Taxes
{
    public sealed class Tax
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Code")]
        public string Code { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Percentage")]
        public float Percentage { get; set; }
    }
}