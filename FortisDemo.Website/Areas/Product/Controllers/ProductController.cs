using System.Web.Mvc;
using Fortis.Model;
using FortisDemo.Model.Templates.UserDefined;
using FortisDemo.Products;
using FortisDemo.Web.Mvc.Controllers;
using FortisDemo.Website.Areas.Product.Models;
using Helpfulcore.RenderingExceptions;

namespace FortisDemo.Website.Areas.Product.Controllers
{
	public class ProductController : WebsiteController
	{
		protected readonly IProductService ProductService;

		public ProductController(IItemFactory itemFactory, IProductService productService) 
			: base(itemFactory)
		{
			this.ProductService = productService;
		}

		public ActionResult ProductList()
		{
			var renderingModel = new ProductListRenderingModel(this.ItemFactory.GetRenderingContextItems<IContentPageItem, IProductRepositoryItem>());
			
			// validate data source
			if (renderingModel.RenderingItem == null)
			{
				throw new RenderingParametersException("Data Source");
			}

			renderingModel.Products = this.ProductService.GetAllProducts(renderingModel.RenderingItem.ItemID);

			return this.View(renderingModel);
		}
	}
}