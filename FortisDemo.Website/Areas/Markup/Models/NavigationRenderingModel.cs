using System.Collections.Generic;
using Fortis.Model;
using FortisDemo.Model.Templates.UserDefined;

namespace FortisDemo.Website.Areas.Markup.Models
{
    public class NavigationRenderingModel : RenderingModel<IContentPageItem, IContentPageItem>
    {
        public NavigationRenderingModel(IRenderingModel<IContentPageItem, IContentPageItem> renderingModel)
            : base(renderingModel.PageItem, renderingModel.RenderingItem, renderingModel.Factory)
        {
        }

        public NavigationRenderingModel(IRenderingModel<IContentPageItem, IContentPageItem> renderingModel, IEnumerable<INavigationItem> navigationItems)
            :this(renderingModel)
        {
            this.NavigationItems = navigationItems;
        }

        public IEnumerable<INavigationItem> NavigationItems { get; set; }
    }
}