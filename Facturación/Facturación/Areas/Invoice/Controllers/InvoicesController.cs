using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturación.Areas.Invoice.Controllers
{
    public class InvoicesController : Controller
    {
        // GET: Invoice/Invoices
        public ActionResult Index()
        {
            return View();
        }

        // GET: Invoice/Invoices/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Invoice/Invoices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Invoices/Create
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

        // GET: Invoice/Invoices/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Invoice/Invoices/Edit/5
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

        // GET: Invoice/Invoices/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Invoice/Invoices/Delete/5
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
