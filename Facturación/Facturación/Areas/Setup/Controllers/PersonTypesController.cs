using Facturación.Entities.PersonTypes;
using MongoDB.Bson;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class PersonTypesController : Controller
    {
        readonly PersonTypeRepository repository = new PersonTypeRepository();
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
        public ActionResult Create(PersonType personType)
        {
            try
            {
                repository.Insert(personType);

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
                var personType = repository.Get(objectId);
                return View(personType);
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult Edit(string id, PersonType personType)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var doc = new BsonDocument
                {
                    { "code", personType.Code },
                    { "name", personType.Name }
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
