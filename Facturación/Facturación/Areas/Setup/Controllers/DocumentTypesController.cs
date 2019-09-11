using Facturación.Entities.DocumentTypes;
using MongoDB.Bson;
using System;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class DocumentTypesController : Controller
    {
        readonly DocumentTypeRepository repository = new DocumentTypeRepository();
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

        public ActionResult Create()
        {
            return View();
        }

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
            try
            {
                var objectId = ObjectId.Parse(id);
                var documentType = repository.Get(objectId);
                return View(documentType);
            }
            catch
            {
                return View();
            }
        }

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
            catch
            {
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
