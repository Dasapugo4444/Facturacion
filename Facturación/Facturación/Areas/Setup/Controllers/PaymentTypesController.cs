using Facturación.Entities.PaymentTypes;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class PaymentTypesController : Controller
    {
        PaymentTypeRepository repository = new PaymentTypeRepository();

        // GET: Setup/PaymentTypes
        public ActionResult Index()
        {
            var list = repository.GetAll();
            return View(list);
        }

        // GET: Setup/PaymentTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Setup/PaymentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setup/PaymentTypes/Create
        [HttpPost]
        public ActionResult Create(PaymentType paymentType)
        {
            try
            {
                repository.Insert(paymentType);
                return RedirectToAction("Index","PaymentTypes");
            }
            catch
            {
                return View();
            }
        }

        // GET: Setup/PaymentTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Setup/PaymentTypes/Edit/5
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

        // GET: Setup/PaymentTypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Setup/PaymentTypes/Delete/5
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
