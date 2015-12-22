using System.Web.Mvc;
using Fortis.Model;
using FortisDemo.Model.Templates.UserDefined;
using FortisDemo.Web.Mvc.Controllers;

namespace FortisDemo.Website.Areas.ContentPage.Controllers
{
    public class ContentPageController : WebsiteController
    {
        public ContentPageController(IItemFactory itemFactory) 
            : base(itemFactory)
        {
        }

        public ActionResult ContentBody()
        {
            return View(this.ItemFactory.GetRenderingContextItems<IContentBodyItem, IContentBodyItem>());
        }

        public ActionResult PageTitle()
        {
            return View(this.ItemFactory.GetRenderingContextItems<IContentTitleItem, IContentTitleItem>());
        }
    }
}