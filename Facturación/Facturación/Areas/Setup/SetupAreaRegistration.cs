using System.Web.Mvc;

namespace Facturacion.Areas.Setup
{
    public class SetupAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Setup";

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
                "Setup_Default",
                "Setup/{controller}/{action}/{id}",
                new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}