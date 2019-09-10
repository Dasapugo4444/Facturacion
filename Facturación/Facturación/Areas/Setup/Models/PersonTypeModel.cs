using Facturación.Entities.PersonTypes;
using Facturación.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Models
{
    public class PersonTypeModel
    {
        public static SelectList GetTaxes(bool itemSelection = true, string defaultItem = null)
        {
            TaxRepository taxRepository = new TaxRepository();
            var list = taxRepository.GetAll();
            var items = list.Select(i => new SelectListItem {
                Value = i.Id.ToString(),
                Text = i.Name
            }).ToList();

            if (itemSelection)
            {
                items.Insert(0, new SelectListItem { Value = "", Text = @"..." });
            }

            return new SelectList(items, "Value", "Text", defaultItem);
        }
    }
}