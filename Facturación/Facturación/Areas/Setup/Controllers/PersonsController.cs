using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Persons.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Setup/Persons
        public ActionResult Index()
        {
            return View();
        }

        // GET: Setup/Persons/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Setup/Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setup/Persons/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Setup/Persons/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Setup/Persons/Edit/5
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

        // GET: Setup/Persons/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Setup/Persons/Delete/5
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
