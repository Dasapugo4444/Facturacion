using Facturación.Connections;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace Facturación.Entities.Invoices
{
    public class InvoiceRepository : Repository<Invoice>
    {
        public void Add(Invoice invoice)
        {
            try
            {
                var col = db.GetCollection<BsonDocument>("invoice");
                col.InsertOne(invoice.ToBsonDocument());
            }
            catch (Exception ex)
            {
                Console.WriteLine("error >>> " + ex.Message);
            }
        }
    }
}