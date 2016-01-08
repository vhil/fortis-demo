using System.Web.Mvc;
using Fortis.Model;
using FortisDemo.Model.Templates.UserDefined;
using FortisDemo.Navigation;
using FortisDemo.Web.Mvc.Controllers;
using FortisDemo.Website.Areas.Markup.Models;

namespace FortisDemo.Website.Areas.Markup.Controllers
{
    public class MarkupController : WebsiteController
    {
        protected readonly INavigationService NavigationService;

        public MarkupController(IItemFactory itemFactory, INavigationService navigationService) 
            : base(itemFactory)
        {
            this.NavigationService = navigationService;
        }

        public ActionResult Header()
        {
            var renderingModel = this.ItemFactory.GetRenderingContextItems<IContentPageItem, IContentPageItem>();
            var siteRoot = this.ItemFactory.GetSiteRoot<ISiteRootItem>();

            var headerModel = new HeaderRenderingModel(renderingModel)
            {
                SiteRoot = siteRoot,
                NavigationItems = this.NavigationService.GetNavigation<INavigationItem>(siteRoot, page => !page.HideFromNavigation.Value)
            };

            return View(headerModel);
        }

        public ActionResult Footer()
        {
            var renderingModel = this.ItemFactory.GetRenderingContextItems<IContentPageItem, IContentPageItem>();
            var siteRoot = this.ItemFactory.GetSiteRoot<ISiteRootItem>();

            var footerModel = new NavigationRenderingModel(renderingModel)
            {
                NavigationItems = this.NavigationService.GetNavigation<INavigationItem>(siteRoot, page => !page.HideFromNavigation.Value)
            };

            return View(footerModel);
        }

        public ActionResult TwoColumnGrid()
        {
            return View(this.ItemFactory.GetRenderingContextItems<IContentImageItem, IContentImageItem>());
        }
    }
}