using System.Web.Mvc;
using Fortis.Model;
using FortisDemo.Model.Templates.UserDefined;
using FortisDemo.Products;
using FortisDemo.Web.Mvc.Controllers;
using FortisDemo.Website.Areas.Products.Models;

namespace FortisDemo.Website.Areas.Products.Controllers
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
			var renderingModel = new ProductListRenderingModel(this.ItemFactory.GetRenderingContextItems<IContentPageItem, IContentPageItem>())
			{
				Products = this.ProductService.GetAlProducts()
			};

			return View(renderingModel);
		}
	}
}