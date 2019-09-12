using Facturación.Entities.ProductCategories;
using Facturación.Entities.Products;
using Facturación.Entities.Taxes;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class ProductsController : Controller
    {
        readonly ProductRepository repository = new ProductRepository();
        readonly CategoryRepository categoriesRepository = new CategoryRepository();
        readonly TaxRepository taxRepository = new TaxRepository();
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
            // Crea dropdown para categorías
            var categories = categoriesRepository.GetAll();
            List<SelectListItem> categoriesList = new List<SelectListItem>();
            foreach (var c in categories)
            {
                categoriesList.Add(new SelectListItem { Value = c.Code, Text = c.Name });
            }
            ViewBag.Category = new SelectList(categoriesList, "Value", "Text");

            // Crea dropdown para impuestos
            var taxes = taxRepository.GetAll();
            List<SelectListItem> taxesList = new List<SelectListItem>();
            foreach (var t in taxes)
            {
                taxesList.Add(new SelectListItem { Value = t.Code, Text = t.Name });
            }
            ViewBag.Tax = new SelectList(taxesList, "Value", "Text");

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
