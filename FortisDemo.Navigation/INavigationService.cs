using System;
using System.Collections.Generic;
using Fortis.Model;
using FortisDemo.Model.Templates.UserDefined;

namespace FortisDemo.Navigation
{
	public interface INavigationService
	{
        /// <summary>
        /// Gets the navigation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rootNode">The root node.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        IEnumerable<T> GetNavigation<T>(IItemWrapper rootNode, Func<T, bool> filter) where T : INavigationItem;

        /// <summary>
        /// Gets the navigation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rootNodeId">The root node identifier.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        IEnumerable<T> GetNavigation<T>(Guid rootNodeId, Func<T, bool> filter) where T : INavigationItem;

        /// <summary>
        /// Gets the navigation.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <returns></returns>
        IEnumerable<INavigationItem> GetNavigation(IItemWrapper rootNode);

        /// <summary>
        /// Gets the navigation.
        /// </summary>
        /// <param name="rootNodeId">The root node identifier.</param>
        /// <returns></returns>
        IEnumerable<INavigationItem> GetNavigation(Guid rootNodeId);
	}
}
