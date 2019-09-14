using Facturación.Entities.DocumentTypes;
using Facturación.Entities.Persons;
using Facturación.Entities.PersonTypes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class PersonsController : Controller
    {
        readonly PersonRepository repository = new PersonRepository();
        readonly PersonTypeRepository personTypeRepository = new PersonTypeRepository();
        readonly DocumentTypeRepository documentTypeRepository = new DocumentTypeRepository();
        public ActionResult Index()
        {
            try
            {
                var list = repository.GetAll();
                return View(list);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            // Crea dropdown para tipo de persona
            var personTypes = personTypeRepository.GetAll();
            List<SelectListItem> personTypesList = new List<SelectListItem>();
            foreach (var pt in personTypes)
            {
                personTypesList.Add(new SelectListItem { Value = pt.Code, Text = pt.Name });
            }
            ViewBag.PersonType = new SelectList(personTypesList, "Value", "Text");

            // Crea dropdown para tipo de documento
            var documentTypes = documentTypeRepository.GetAll();
            List<SelectListItem> documentTypesList = new List<SelectListItem>();
            foreach (var dt in documentTypes)
            {
                documentTypesList.Add(new SelectListItem { Value = dt.Code, Text = dt.Name });
            }
            ViewBag.DocumentType = new SelectList(documentTypesList, "Value", "Text");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                repository.Insert(person);
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
                var person = repository.Get(objectId);

                // Crea dropdown para tipo de persona
                var personTypes = personTypeRepository.GetAll();
                List<SelectListItem> personTypesList = new List<SelectListItem>();
                foreach (var pt in personTypes)
                {
                    personTypesList.Add(new SelectListItem { Value = pt.Code, Text = pt.Name });
                }
                ViewBag.PersonType = new SelectList(personTypesList, "Value", "Text", person.PersonType);

                // Crea dropdown para tipo de documento
                var documentTypes = documentTypeRepository.GetAll();
                List<SelectListItem> documentTypesList = new List<SelectListItem>();
                foreach (var dt in documentTypes)
                {
                    documentTypesList.Add(new SelectListItem { Value = dt.Code, Text = dt.Name });
                }
                ViewBag.DocumentType = new SelectList(documentTypesList, "Value", "Text", person.DocumentType);
                return View(person);
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult Edit(string id, Person person)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var doc = new BsonDocument
                {
                    { "personType", person.PersonType },
                    { "firstName", person.FirstName },
                    { "surName", person.SurName },
                    { "identificationType", person.DocumentType },
                    { "identificationNumber", person.IdentificationNumber },
                    { "phone", person.Phone }
                };
                repository.Update(objectId, doc);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
