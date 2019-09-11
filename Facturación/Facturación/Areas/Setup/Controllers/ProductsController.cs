using Facturación.Entities.Products;
using MongoDB.Bson;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class ProductsController : Controller
    {
        readonly ProductRepository repository = new ProductRepository();
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
        public ActionResult Create(Product product)
        {
            try
            {
                repository.Insert(product);
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
                var product = repository.Get(objectId);
                return View(product);
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult Edit(string id, string name, string category, float price, string stock, string tax)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var doc = new BsonDocument
                {
                    { "name", name },
                    { "category", category },
                    { "price", price },
                    { "stock", stock },
                    { "tax", tax }
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
