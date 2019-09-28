using Facturación.Entities.Taxes;
using MongoDB.Bson;
using System;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class TaxesController : Controller
    {
        readonly TaxRepository repository = new TaxRepository();
        public ActionResult Index()
        {
            var list = repository.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tax tax)
        {
            try
            {
                repository.Insert(tax);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var tax = repository.Get(objectId);
                return View(tax);
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult Edit(string id, Tax tax)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var doc = new BsonDocument
                {
                    { "code", tax.Code },
                    { "name", tax.Name },
                    { "percentage", tax.Percentage }
                };
                repository.Update(objectId, doc);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

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
