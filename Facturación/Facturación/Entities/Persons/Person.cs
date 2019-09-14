using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Facturación.Entities.DocumentTypes;

namespace Facturación.Entities.Persons
{
    public sealed class Person
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("PersonType")]
        public string PersonType { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("SurName")]
        public string SurName { get; set; }
        [BsonElement("DocumentType")]
        public string DocumentType { get; set; }
        [BsonElement("IdentificationNumber")]
        public string IdentificationNumber { get; set; }
        [BsonElement("Phone")]
        public int Phone { get; set; }

    }
}