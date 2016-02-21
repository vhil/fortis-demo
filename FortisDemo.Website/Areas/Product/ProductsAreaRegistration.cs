using System.Web.Mvc;

namespace FortisDemo.Website.Areas.Product
{
    public class ProductsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
				return "ProductsArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Products_default",
                "ProductsArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}