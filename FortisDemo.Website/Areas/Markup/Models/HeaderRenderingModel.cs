using System.Linq;
using Fortis.Model;
using FortisDemo.Model.Templates.UserDefined;

namespace FortisDemo.Website.Areas.Markup.Models
{
    public class HeaderRenderingModel : NavigationRenderingModel
    {
        public HeaderRenderingModel(IRenderingModel<IContentPageItem, IContentPageItem> model)
            : base(model)
        {
            this.NavigationItems = Enumerable.Empty<INavigationItem>();
        }

        public ISiteRootItem SiteRoot { get; set; }
    }
}