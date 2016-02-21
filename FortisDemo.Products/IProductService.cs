using System.Collections.Generic;
using FortisDemo.Model.Templates.UserDefined;

namespace FortisDemo.Products
{
	public interface IProductService
	{
		IEnumerable<IProductPageItem> GetAlProducts();
	}
}
