using System.Web.Mvc;

namespace FortisDemo.Website.Areas.Markup
{
    public class LayoutAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Markup";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Layout_default",
                "Markup/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}