using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
        [BsonElement("Surname")]
        public string SurName { get; set; }
        [BsonElement("IdentificationType")]
        public string IdentificationType { get; set; }
        [BsonElement("IdentificationNumber")]
        public string IdentificationNumber { get; set; }

    }
}