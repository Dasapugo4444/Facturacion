using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturación.Entities
{
    public sealed class Invoice
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Place")]
        public string Place { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }
        [BsonElement("Number")]
        public int Number { get; set; }
        [BsonElement("Emmiter")]
        public Person Emmiter { get; set; }
        [BsonElement("Receiver")]
        public Person Receiver { get; set; }
        [BsonElement("Product")]
        public Product Product { get; set; }
        [BsonElement("Quantity")]
        public int Quantity { get; set; }
        [BsonElement("TotalPrice")]
        public float TotalPrice { get; set; }
        [BsonElement("Tax")]
        public Tax Tax { get; set; }
    }
}