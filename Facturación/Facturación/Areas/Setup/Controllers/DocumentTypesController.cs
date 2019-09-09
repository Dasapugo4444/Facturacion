using Facturación.Entities.DocumentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class DocumentTypesController : Controller
    {
        DocumentTypeRepository repository = new DocumentTypeRepository();
        // GET: Setup/DocumentTypes
        public ActionResult Index()
        {
            var list = repository.GetAll();
            return View(list);
        }

        // GET: Setup/DocumentTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Setup/DocumentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setup/DocumentTypes/Create
        [HttpPost]
        public ActionResult Create(DocumentType documentType)
        {
            try
            {
                repository.Insert(documentType);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Setup/DocumentTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Setup/DocumentTypes/Edit/5
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

        // GET: Setup/DocumentTypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Setup/DocumentTypes/Delete/5
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
