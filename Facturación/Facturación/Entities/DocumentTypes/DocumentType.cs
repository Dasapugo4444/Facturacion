using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturación.Entities.DocumentTypes
{
    public class DocumentType
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Code")]
        public string Code{ get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}