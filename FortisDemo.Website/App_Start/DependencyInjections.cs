using System.Reflection;
using System.Web.Mvc;
using Fortis;
using Fortis.Model;
using Fortis.Mvc.Providers;
using Fortis.Providers;
using Fortis.Search;
using FortisDemo.Navigation;
using FortisDemo.Products;
using FortisDemo.Website;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(DependencyInjections), "Initialize", Order = 100)]

namespace FortisDemo.Website
{
	public static class DependencyInjections
	{
		public static void Initialize()
		{
			var container = new Container();

			RegisterFortis(container);
		    RegisterFortisDemoWebsiteTypes(container);
			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
			container.RegisterMvcIntegratedFilterProvider();

			// Register the container as MVC IDependencyResolver.
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

			// Initialise fortis - this is required for places where we can't use DI
			Global.Initialise(
				container.GetInstance<ISpawnProvider>(),
				container.GetInstance<IItemFactory>(),
				container.GetInstance<IItemSearchFactory>()
			);
		}

	    private static void RegisterFortisDemoWebsiteTypes(Container container)
	    {
			 container.Register<IProductService, ProductService>();
	         container.Register<INavigationService, NavigationService>();
	    }

	    private static void RegisterFortis(Container container)
		{
			container.Register<IItemFactory, ItemFactory>(Lifestyle.Singleton);
			container.Register<IContextProvider, ContextProvider>(Lifestyle.Singleton);
			container.Register<ISpawnProvider, SpawnProvider>(Lifestyle.Singleton);
			container.Register<ITemplateMapProvider, TemplateMapProvider>(Lifestyle.Singleton);
			container.Register<IModelAssemblyProvider, ModelAssemblyProvider>(Lifestyle.Singleton);
			container.Register<ISearchResultsAdapter, SearchResultsAdapter>(Lifestyle.Singleton);
			container.Register<IItemSearchFactory, ItemSearchFactory>(Lifestyle.Singleton);
		}
	}
}