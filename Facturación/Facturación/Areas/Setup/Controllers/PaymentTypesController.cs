using Facturación.Entities.PaymentTypes;
using MongoDB.Bson;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class PaymentTypesController : Controller
    {
        readonly PaymentTypeRepository repository = new PaymentTypeRepository();
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
        public ActionResult Create(PaymentType paymentType)
        {
            try
            {
                repository.Insert(paymentType);
                return RedirectToAction("Index", "PaymentTypes");
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
                var paymentType = repository.Get(objectId);
                return View(paymentType);
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult Edit(string id, PaymentType paymentType)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var doc = new BsonDocument
                {
                    { "code", paymentType.Code },
                    { "name", paymentType.Name }
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
