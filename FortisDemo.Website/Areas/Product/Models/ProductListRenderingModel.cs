using System.Collections.Generic;
using Fortis.Model;
using FortisDemo.Model.Templates.UserDefined;

namespace FortisDemo.Website.Areas.Product.Models
{
	public class ProductListRenderingModel : RenderingModel<IContentPageItem, IProductRepositoryItem>
	{
		public ProductListRenderingModel(IRenderingModel<IContentPageItem, IProductRepositoryItem> model)
			: base(model.PageItem, model.RenderingItem, model.Factory)
		{
		}

		public IEnumerable<IProductPageItem> Products { get; set; }
	}
}