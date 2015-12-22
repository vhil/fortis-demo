using System;
using System.Collections.Generic;
using System.Linq;
using Fortis.Model;
using FortisDemo.Model.Templates.UserDefined;

namespace FortisDemo.Navigation
{
	public class NavigationService : INavigationService
	{
		protected readonly IItemFactory ItemFactory;

		public NavigationService(IItemFactory itemFactory)
		{
			this.ItemFactory = itemFactory;
		}

		public IEnumerable<T> GetNavigation<T>(IItemWrapper rootNode, Func<T, bool> filter) where T : INavigationItem
		{
			if (rootNode == null)
			{
				throw new ArgumentOutOfRangeException("rootNode", "The rootNode is invalid");
			}

			var navigationItems = filter != null
				? rootNode.Children<T>().Where(filter).ToList()
				: rootNode.Children<T>().ToList();

			return navigationItems;
		}

		public IEnumerable<T> GetNavigation<T>(Guid rootNodeId, Func<T, bool> filter) where T : INavigationItem
        {
			if (rootNodeId == Guid.Empty)
			{
				throw new ArgumentOutOfRangeException("rootNodeId", "The rootNodeId is invalid");
			}

			var rootItem = this.ItemFactory.Select<IItemWrapper>(rootNodeId);

			return this.GetNavigation(rootItem, filter);
		}

		public IEnumerable<INavigationItem> GetNavigation(IItemWrapper rootNode)
		{
			return this.GetNavigation<INavigationItem>(rootNode, null);
		}

		public IEnumerable<INavigationItem> GetNavigation(Guid rootNodeId)
		{
			return this.GetNavigation<INavigationItem>(rootNodeId, null);
		}
	}
}