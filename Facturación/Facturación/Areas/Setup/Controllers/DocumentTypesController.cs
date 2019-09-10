using Facturación.Entities.DocumentTypes;
using MongoDB.Bson;
using System;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class DocumentTypesController : Controller
    {
        DocumentTypeRepository repository = new DocumentTypeRepository();
        // GET: Setup/DocumentTypes
        public ActionResult Index()
        {
            var list = repository.GetAll();
            return View(list);
        }

        // GET: Setup/DocumentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setup/DocumentTypes/Create
        [HttpPost]
        public ActionResult Create(DocumentType documentType)
        {
            try
            {
                repository.Insert(documentType);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var objectId = ObjectId.Parse(id);

            var documentType = repository.Get(objectId);
            return View(documentType);
        }

        // POST: Setup/DocumentTypes/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, string code, string name)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var doc = new BsonDocument {
                    { "code", code },
                    { "name", name }
                };
                repository.Update(objectId, doc);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // GET: Setup/DocumentTypes/Delete/5
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
