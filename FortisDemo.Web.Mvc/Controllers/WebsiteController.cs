using Fortis.Model;
using Sitecore.Mvc.Controllers;

namespace FortisDemo.Web.Mvc.Controllers
{
    public abstract class WebsiteController : SitecoreController
    {
        protected readonly IItemFactory ItemFactory;

        protected WebsiteController(IItemFactory itemFactory)
        {
            this.ItemFactory = itemFactory;
        }
    }
}
