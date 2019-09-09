using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class PersonTypesController : Controller
    {
        // GET: Setup/PersonTypes
        public ActionResult Index()
        {
            return View();
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
