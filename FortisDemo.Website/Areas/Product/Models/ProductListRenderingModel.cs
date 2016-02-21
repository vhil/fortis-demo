using System.Collections.Generic;
using Fortis.Model;
using FortisDemo.Model.Templates.UserDefined;

namespace FortisDemo.Website.Areas.Products.Models
{
	public class ProductListRenderingModel : RenderingModel<IContentPageItem, IContentPageItem>
	{
		public ProductListRenderingModel(IRenderingModel<IContentPageItem, IContentPageItem> model)
			: base(model.PageItem, model.RenderingItem, model.Factory)
		{
		}

		public IEnumerable<IProductPageItem> Products { get; set; }
	}
}