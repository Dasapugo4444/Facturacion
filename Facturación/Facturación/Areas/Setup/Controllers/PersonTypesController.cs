using Facturación.Entities.PersonTypes;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class PersonTypesController : Controller
    {
        PersonTypeRepository repository = new PersonTypeRepository();
        // GET: Setup/PersonTypes
        public ActionResult Index()
        {
            var list = repository.GetAll();
            return View(list);
        }

        // GET: Setup/PersonTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Setup/PersonTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setup/PersonTypes/Create
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

        // GET: Setup/PersonTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Setup/PersonTypes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Setup/PersonTypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Setup/PersonTypes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
