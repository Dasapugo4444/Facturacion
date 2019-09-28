using Facturación.Entities.Products;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Facturación.Entities.Invoices
{
    public sealed class Invoice
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Customer")]
        public string Customer { get; set; }
        [BsonElement("OrderNumber")]
        public int OrderNumber { get; set; }
        [BsonElement("PaymentType")]
        public string PaymentType { get; set; }
        [BsonElement("Date")]
        public string Date { get; set; }
        [BsonElement("Seller")]
        public string Seller { get; set; }
        [BsonElement("Products")]
        public BsonDocument Products { get; set; }
        [BsonElement("Product")]
        public Product Product { get; set; }
        [BsonElement("TotalPrice")]
        public float TotalPrice { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Quantity")]
        public int Quantity { get; set; }
    }
}