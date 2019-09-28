using Facturación.Entities.Invoices;
using Facturación.Entities.PaymentTypes;
using Facturación.Entities.Persons;
using Facturación.Entities.Products;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturación.Areas.Invoicing.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly InvoiceRepository repository = new InvoiceRepository();
        private readonly PersonRepository personRepository = new PersonRepository();
        private readonly PaymentTypeRepository paymentTypeRepository = new PaymentTypeRepository();
        private readonly ProductRepository productRepository = new ProductRepository();

        // GET: Invoicing/Invoices
        public ActionResult Index()
        {
            try
            {
                var list = repository.GetAll();
                return View(list);
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoicing/Invoices/Create
        public ActionResult Create()
        {

            // Crea dropdwon de clientes
            var customers = personRepository.GetCustomers();
            List<SelectListItem> customersList = new List<SelectListItem>();
            foreach (var c in customers)
            {
                customersList.Add(new SelectListItem { Value = c.IdentificationNumber, Text = $"{c.FirstName} {c.SurName}" });
            }
            ViewBag.Customer = new SelectList(customersList, "Value", "Text");

            // Crea dropdwon de clientes
            var sellers = personRepository.GetCustomers();
            List<SelectListItem> sellersList = new List<SelectListItem>();
            foreach (var c in customers)
            {
                sellersList.Add(new SelectListItem { Value = c.IdentificationNumber, Text = $"{c.FirstName} {c.SurName}" });
            }
            ViewBag.Seller = new SelectList(sellersList, "Value", "Text");

            // Crea dropdown de formas de pago
            var paymentTypes = paymentTypeRepository.GetAll();
            List<SelectListItem> paymentTypesList = new List<SelectListItem>();
            foreach (var pt in paymentTypes)
            {
                paymentTypesList.Add(new SelectListItem { Value = pt.Code, Text = pt.Name });
            }
            ViewBag.PaymentType = new SelectList(paymentTypesList, "Value", "Text");

            // Crea dropdown de productos
            var products = productRepository.GetAll();
            List<SelectListItem> productsList = new List<SelectListItem>();
            foreach (var p in products)
            {
                productsList.Add(new SelectListItem { Value = p.Code, Text = p.Name });
            }
            ViewBag.Product = new SelectList(productsList, "Value", "Text");

            return View();
        }

        // POST: Invoicing/Invoices/Create
        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            try
            {
                repository.Insert(invoice);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoicing/Invoices/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var invoice = repository.Get(objectId);
                return View(invoice);
            }
            catch
            {
                return null;
            }
        }

        // POST: Invoicing/Invoices/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Invoice invoice)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var doc = new BsonDocument
                {
                    { "customer", invoice.Customer },
                    { "orderNumber", invoice.OrderNumber },
                    { "paymentType", invoice.PaymentType },
                    { "date", invoice.Date },
                    { "seller", invoice.Seller },
                    { "products", invoice.Products },
                    { "totalPrice", invoice.TotalPrice }
                };
                repository.Update(objectId, doc);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Invoicing/Invoices/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                repository.Delete(objectId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
