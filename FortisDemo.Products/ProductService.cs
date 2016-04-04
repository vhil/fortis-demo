using System;
using System.Collections.Generic;
using System.Linq;
using Fortis.Search;
using FortisDemo.Model.Templates.UserDefined;
using Sitecore;
using Sitecore.ContentSearch;

namespace FortisDemo.Products
{
	public class ProductService : IProductService
	{
		protected readonly IItemSearchFactory ItemSearchFactory;

		public ProductService(IItemSearchFactory itemSearchFactory)
		{
			this.ItemSearchFactory = itemSearchFactory;
		}

		public IEnumerable<IProductPageItem> GetAllProducts(Guid productRepositoryID)
		{
			using (var searchContext = ContentSearchManager.CreateSearchContext((SitecoreIndexableItem)Context.Item))
			{
				var queryable = searchContext.GetQueryable<IProductPageItem>();

				return this.ItemSearchFactory.FilteredSearch(queryable)
					.Where(x => x.Paths.Contains(productRepositoryID))
					.ToList();
			}
		}
	}
}