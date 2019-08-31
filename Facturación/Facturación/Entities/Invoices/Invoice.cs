using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Facturación.Entities.Invoices
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
        public Persons.Person Emmiter { get; set; }
        [BsonElement("Receiver")]
        public Persons.Person Receiver { get; set; }
        [BsonElement("Product")]
        public Products.Product Product { get; set; }
        [BsonElement("Quantity")]
        public int Quantity { get; set; }
        [BsonElement("TotalPrice")]
        public float TotalPrice { get; set; }
        [BsonElement("Tax")]
        public Taxes.Tax Tax { get; set; }
    }
}