using Facturación.Connections;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Facturación.Entities.Invoices
{
    public class InvoiceRepository
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Invoice> collection;

        public InvoiceRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("facturacion");
            collection = database.GetCollection<Invoice>("invoices");
        }

        public void Insert(Invoice invoice)
        {
            collection.InsertOne(invoice);
        }

        public void Update(ObjectId id, BsonDocument doc)
        {
            var filter = Builders<Invoice>.Filter.Eq("_id", id);
            var item = Builders<Invoice>.Update
                .Set("Customer", doc.GetValue("customer"))
                .Set("OrderNumber", doc.GetValue("orderNumber"))
                .Set("PaymentType", doc.GetValue("paymentType"))
                .Set("Date", doc.GetValue("date"))
                .Set("Seller", doc.GetValue("seller"))
                .Set("Products", doc.GetValue("products"))
                .Set("TotalPrice", doc.GetValue("totalPrice"));
            collection.FindOneAndUpdate(filter, item);
        }

        public void Delete(ObjectId id)
        {
            collection.FindOneAndDelete(Builders<Invoice>.Filter.Eq("_id", id));
        }

        public List<Invoice> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        public Invoice Get(ObjectId id)
        {
            return collection.Find<Invoice>(i => i.Id == id).FirstOrDefault();
        }
    }
}