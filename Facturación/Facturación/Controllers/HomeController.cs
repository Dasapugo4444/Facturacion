using System.Web.Mvc;

namespace Facturación.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }
    }
}