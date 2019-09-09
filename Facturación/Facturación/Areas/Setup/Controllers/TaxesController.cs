using Facturación.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class TaxesController : Controller
    {
        TaxRepository repository = new TaxRepository();
        // GET: Setup/Taxes
        public ActionResult Index()
        {
            var list = repository.GetAll();
            return View(list);
        }

        // GET: Setup/Taxes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Setup/Taxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setup/Taxes/Create
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

        // GET: Setup/Taxes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Setup/Taxes/Edit/5
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

        // GET: Setup/Taxes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Setup/Taxes/Delete/5
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
