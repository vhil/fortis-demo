using global::Sitecore.Data.Items;
using global::Sitecore.ContentSearch;
using global::Sitecore.ContentSearch.Linq.Common;

#region Sitecore Item (Extendable base class)

namespace FortisDemo.Model
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/*
		To extend base Fortis.Model.ItemWrapper class and its interface, 
		create partial class SitecoreItem and partial interface ISitecoreItem
		in your model project and add required properties or methods there.
	*/
	public partial interface ISitecoreItem : IItemWrapper
	{
		[IndexField(SitecoreItem.IndexFieldNames.UpdatedDate)]
		IDateTimeFieldWrapper UpdatedDate { get; }

		[IndexField(SitecoreItem.IndexFieldNames.UpdatedDate)]
		DateTime UpdatedDateValue { get; }

		[IndexField(SitecoreItem.IndexFieldNames.CreatedDate)]
		IDateTimeFieldWrapper CreatedDate { get; }

		[IndexField(SitecoreItem.IndexFieldNames.CreatedDate)]
		DateTime CreatedDateValue { get; }
	}

	public partial class SitecoreItem : ItemWrapper, ISitecoreItem
	{
		public SitecoreItem(ISpawnProvider spawnProvider) 
			: base(spawnProvider)
		{
		}

		public SitecoreItem(Item item, ISpawnProvider spawnProvider) 
			: base(item, spawnProvider)
		{
		}

		public SitecoreItem(Guid id, ISpawnProvider spawnProvider) 
			: base(id, spawnProvider)
		{
		}

		public SitecoreItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) 
			: base(id, lazyFields, spawnProvider)
		{
		}

		[IndexField(IndexFieldNames.UpdatedDate)]
		public virtual IDateTimeFieldWrapper UpdatedDate
		{
			get { return GetField<DateTimeFieldWrapper>(FieldNames.UpdatedDate, IndexFieldNames.UpdatedDate); }
		}

		[IndexField(IndexFieldNames.UpdatedDate)]
		public virtual DateTime UpdatedDateValue
		{
			get { return this.UpdatedDate.Value; }
		}

		[IndexField(IndexFieldNames.CreatedDate)]
		public virtual IDateTimeFieldWrapper CreatedDate
		{
			get { return GetField<DateTimeFieldWrapper>(FieldNames.CreatedDate, IndexFieldNames.CreatedDate); }
		}

		[IndexField(IndexFieldNames.CreatedDate)]
		public virtual DateTime CreatedDateValue
		{
			get { return this.CreatedDate.Value; }
		}

		#region SitecoreItem Constants

		public static partial class FieldNames
		{
			public const string UpdatedDate = "__Updated";
			public const string CreatedDate = "__Created";
		}

		public static partial class IndexFieldNames
		{
			public const string UpdatedDate = "__smallupdateddate";
			public const string CreatedDate = "__smallcreateddate";
		}

		#endregion
	}
}

#endregion


#region Home Page (UserDefined)

namespace FortisDemo.Model.Templates.UserDefined
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Home Page</para>
	/// <para>ID: {0C4BBB1E-5B0F-41AA-B5A0-E3226076C676}</para>
	/// <para>/sitecore/templates/User Defined/Page Types/Home Page</para>
	/// </summary>
	[TemplateMapping(HomePageItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface IHomePageItem : ISitecoreItem , FortisDemo.Model.Templates.UserDefined.IContentPageItem
	{		
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/User Defined/Page Types/Home Page</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, HomePageItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(HomePageItem.Constants.TemplateIdStr, "")]
	public partial class HomePageItem : SitecoreItem, IHomePageItem
	{
		private Item _item = null;

		public HomePageItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public HomePageItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public HomePageItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public HomePageItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

		/// <summary><para>Template: Home Page</para><para>Field: HideFromNavigation</para><para>Data type: Checkbox</para></summary>
		[IndexField(IndexFieldNames.HideFromNavigation)]
		public virtual IBooleanFieldWrapper HideFromNavigation
		{
			get { return GetField<BooleanFieldWrapper>(FieldNames.HideFromNavigation, IndexFieldNames.HideFromNavigation); }
		}

		/// <summary><para>Template: Home Page</para><para>Field: HideFromNavigation</para><para>Data type: Checkbox</para></summary>
		[IndexField(IndexFieldNames.HideFromNavigation)]
		public bool HideFromNavigationValue
		{
			get { return HideFromNavigation.Value; }
		}
		/// <summary><para>Template: Home Page</para><para>Field: NavigationTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.NavigationTitle)]
		public virtual ITextFieldWrapper NavigationTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.NavigationTitle, IndexFieldNames.NavigationTitle); }
		}

		/// <summary><para>Template: Home Page</para><para>Field: NavigationTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.NavigationTitle)]
		public string NavigationTitleValue
		{
			get { return NavigationTitle.Value; }
		}
		/// <summary><para>Template: Home Page</para><para>Field: ContentTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ContentTitle)]
		public virtual ITextFieldWrapper ContentTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.ContentTitle, IndexFieldNames.ContentTitle); }
		}

		/// <summary><para>Template: Home Page</para><para>Field: ContentTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ContentTitle)]
		public string ContentTitleValue
		{
			get { return ContentTitle.Value; }
		}
		/// <summary><para>Template: Home Page</para><para>Field: ContentBody</para><para>Data type: Rich Text</para></summary>
		[IndexField(IndexFieldNames.ContentBody)]
		public virtual IRichTextFieldWrapper ContentBody
		{
			get { return GetField<RichTextFieldWrapper>(FieldNames.ContentBody, IndexFieldNames.ContentBody); }
		}

		/// <summary><para>Template: Home Page</para><para>Field: ContentBody</para><para>Data type: Rich Text</para></summary>
		[IndexField(IndexFieldNames.ContentBody)]
		public string ContentBodyValue
		{
			get { return ContentBody.Value; }
		}
		/// <summary><para>Template: Home Page</para><para>Field: ContentImage</para><para>Data type: Image</para></summary>
		public virtual IImageFieldWrapper ContentImage
		{
			get { return GetField<ImageFieldWrapper>(FieldNames.ContentImage); }
		}

		/// <summary><para>Template: Home Page</para><para>Field: ContentImage</para><para>Data type: Image</para></summary>
		public string ContentImageValue
		{
			get { return ContentImage.Value; }
		}
		/// <summary><para>Template: Home Page</para><para>Field: MetaDescription</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaDescription)]
		public virtual ITextFieldWrapper MetaDescription
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaDescription, IndexFieldNames.MetaDescription); }
		}

		/// <summary><para>Template: Home Page</para><para>Field: MetaDescription</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaDescription)]
		public string MetaDescriptionValue
		{
			get { return MetaDescription.Value; }
		}
		/// <summary><para>Template: Home Page</para><para>Field: MetaKeywords</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaKeywords)]
		public virtual ITextFieldWrapper MetaKeywords
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaKeywords, IndexFieldNames.MetaKeywords); }
		}

		/// <summary><para>Template: Home Page</para><para>Field: MetaKeywords</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaKeywords)]
		public string MetaKeywordsValue
		{
			get { return MetaKeywords.Value; }
		}
		/// <summary><para>Template: Home Page</para><para>Field: MetaTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaTitle)]
		public virtual ITextFieldWrapper MetaTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaTitle, IndexFieldNames.MetaTitle); }
		}

		/// <summary><para>Template: Home Page</para><para>Field: MetaTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaTitle)]
		public string MetaTitleValue
		{
			get { return MetaTitle.Value; }
		}
	
		#region HomePageItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{0C4BBB1E-5B0F-41AA-B5A0-E3226076C676}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
			public const string HideFromNavigation = "Hide From Navigation";
			public const string NavigationTitle = "Navigation Title";
			public const string ContentTitle = "Content Title";
			public const string ContentBody = "Content Body";
			public const string ContentImage = "Content Image";
			public const string MetaDescription = "Meta Description";
			public const string MetaKeywords = "Meta Keywords";
			public const string MetaTitle = "Meta Title";
		}

		public static partial class IndexFieldNames
		{
			public const string HideFromNavigation = "hide_from_navigation";
			public const string NavigationTitle = "navigation_title";
			public const string ContentTitle = "content_title";
			public const string ContentBody = "content_body";
			public const string ContentImage = "content_image";
			public const string MetaDescription = "meta_description";
			public const string MetaKeywords = "meta_keywords";
			public const string MetaTitle = "meta_title";
		}

		#endregion
	}
}

#endregion
#region Site Root (UserDefined)

namespace FortisDemo.Model.Templates.UserDefined
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Site Root</para>
	/// <para>ID: {16C0EF20-4B23-4201-B57D-F8A60BADC17B}</para>
	/// <para>/sitecore/templates/User Defined/Content Tree/Site Root</para>
	/// </summary>
	[TemplateMapping(SiteRootItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface ISiteRootItem : ISitecoreItem 
	{		
		/// <summary>
		/// <para>Template: Site Root</para><para>Field: SiteLogo</para><para>Data type: Image</para>
		/// </summary>
		IImageFieldWrapper SiteLogo { get; }
		string SiteLogoValue { get; }
		/// <summary>
		/// <para>Template: Site Root</para><para>Field: SiteTitle</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(SiteRootItem.IndexFieldNames.SiteTitle)]
		ITextFieldWrapper SiteTitle { get; }

		/// <summary>
		/// <para>Template: Site Root</para><para>Field: SiteTitle</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(SiteRootItem.IndexFieldNames.SiteTitle)]
		string SiteTitleValue { get; }
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/User Defined/Content Tree/Site Root</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, SiteRootItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(SiteRootItem.Constants.TemplateIdStr, "")]
	public partial class SiteRootItem : SitecoreItem, ISiteRootItem
	{
		private Item _item = null;

		public SiteRootItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public SiteRootItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public SiteRootItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public SiteRootItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

		/// <summary><para>Template: Site Root</para><para>Field: SiteLogo</para><para>Data type: Image</para></summary>
		public virtual IImageFieldWrapper SiteLogo
		{
			get { return GetField<ImageFieldWrapper>(FieldNames.SiteLogo); }
		}

		/// <summary><para>Template: Site Root</para><para>Field: SiteLogo</para><para>Data type: Image</para></summary>
		public string SiteLogoValue
		{
			get { return SiteLogo.Value; }
		}
		/// <summary><para>Template: Site Root</para><para>Field: SiteTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.SiteTitle)]
		public virtual ITextFieldWrapper SiteTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.SiteTitle, IndexFieldNames.SiteTitle); }
		}

		/// <summary><para>Template: Site Root</para><para>Field: SiteTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.SiteTitle)]
		public string SiteTitleValue
		{
			get { return SiteTitle.Value; }
		}
	
		#region SiteRootItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{16C0EF20-4B23-4201-B57D-F8A60BADC17B}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
			public const string SiteLogo = "Site Logo";
			public const string SiteTitle = "Site Title";
		}

		public static partial class IndexFieldNames
		{
			public const string SiteLogo = "site_logo";
			public const string SiteTitle = "site_title";
		}

		#endregion
	}
}

#endregion
#region Product Page (UserDefined)

namespace FortisDemo.Model.Templates.UserDefined
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Product Page</para>
	/// <para>ID: {2ECC037F-C1B0-49BF-9E94-311F6CCA8D27}</para>
	/// <para>/sitecore/templates/User Defined/Products/Product Page</para>
	/// </summary>
	[TemplateMapping(ProductPageItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface IProductPageItem : ISitecoreItem , FortisDemo.Model.Templates.UserDefined.IContentPageItem, FortisDemo.Model.Templates.UserDefined.IProductDataItem
	{		
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/User Defined/Products/Product Page</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, ProductPageItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(ProductPageItem.Constants.TemplateIdStr, "")]
	public partial class ProductPageItem : SitecoreItem, IProductPageItem
	{
		private Item _item = null;

		public ProductPageItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public ProductPageItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public ProductPageItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public ProductPageItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

		/// <summary><para>Template: Product Page</para><para>Field: HideFromNavigation</para><para>Data type: Checkbox</para></summary>
		[IndexField(IndexFieldNames.HideFromNavigation)]
		public virtual IBooleanFieldWrapper HideFromNavigation
		{
			get { return GetField<BooleanFieldWrapper>(FieldNames.HideFromNavigation, IndexFieldNames.HideFromNavigation); }
		}

		/// <summary><para>Template: Product Page</para><para>Field: HideFromNavigation</para><para>Data type: Checkbox</para></summary>
		[IndexField(IndexFieldNames.HideFromNavigation)]
		public bool HideFromNavigationValue
		{
			get { return HideFromNavigation.Value; }
		}
		/// <summary><para>Template: Product Page</para><para>Field: NavigationTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.NavigationTitle)]
		public virtual ITextFieldWrapper NavigationTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.NavigationTitle, IndexFieldNames.NavigationTitle); }
		}

		/// <summary><para>Template: Product Page</para><para>Field: NavigationTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.NavigationTitle)]
		public string NavigationTitleValue
		{
			get { return NavigationTitle.Value; }
		}
		/// <summary><para>Template: Product Page</para><para>Field: ContentTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ContentTitle)]
		public virtual ITextFieldWrapper ContentTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.ContentTitle, IndexFieldNames.ContentTitle); }
		}

		/// <summary><para>Template: Product Page</para><para>Field: ContentTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ContentTitle)]
		public string ContentTitleValue
		{
			get { return ContentTitle.Value; }
		}
		/// <summary><para>Template: Product Page</para><para>Field: ContentBody</para><para>Data type: Rich Text</para></summary>
		[IndexField(IndexFieldNames.ContentBody)]
		public virtual IRichTextFieldWrapper ContentBody
		{
			get { return GetField<RichTextFieldWrapper>(FieldNames.ContentBody, IndexFieldNames.ContentBody); }
		}

		/// <summary><para>Template: Product Page</para><para>Field: ContentBody</para><para>Data type: Rich Text</para></summary>
		[IndexField(IndexFieldNames.ContentBody)]
		public string ContentBodyValue
		{
			get { return ContentBody.Value; }
		}
		/// <summary><para>Template: Product Page</para><para>Field: ContentImage</para><para>Data type: Image</para></summary>
		public virtual IImageFieldWrapper ContentImage
		{
			get { return GetField<ImageFieldWrapper>(FieldNames.ContentImage); }
		}

		/// <summary><para>Template: Product Page</para><para>Field: ContentImage</para><para>Data type: Image</para></summary>
		public string ContentImageValue
		{
			get { return ContentImage.Value; }
		}
		/// <summary><para>Template: Product Page</para><para>Field: MetaDescription</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaDescription)]
		public virtual ITextFieldWrapper MetaDescription
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaDescription, IndexFieldNames.MetaDescription); }
		}

		/// <summary><para>Template: Product Page</para><para>Field: MetaDescription</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaDescription)]
		public string MetaDescriptionValue
		{
			get { return MetaDescription.Value; }
		}
		/// <summary><para>Template: Product Page</para><para>Field: MetaKeywords</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaKeywords)]
		public virtual ITextFieldWrapper MetaKeywords
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaKeywords, IndexFieldNames.MetaKeywords); }
		}

		/// <summary><para>Template: Product Page</para><para>Field: MetaKeywords</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaKeywords)]
		public string MetaKeywordsValue
		{
			get { return MetaKeywords.Value; }
		}
		/// <summary><para>Template: Product Page</para><para>Field: MetaTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaTitle)]
		public virtual ITextFieldWrapper MetaTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaTitle, IndexFieldNames.MetaTitle); }
		}

		/// <summary><para>Template: Product Page</para><para>Field: MetaTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaTitle)]
		public string MetaTitleValue
		{
			get { return MetaTitle.Value; }
		}
		/// <summary><para>Template: Product Page</para><para>Field: ProductID</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ProductID)]
		public virtual ITextFieldWrapper ProductID
		{
			get { return GetField<TextFieldWrapper>(FieldNames.ProductID, IndexFieldNames.ProductID); }
		}

		/// <summary><para>Template: Product Page</para><para>Field: ProductID</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ProductID)]
		public string ProductIDValue
		{
			get { return ProductID.Value; }
		}
	
		#region ProductPageItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{2ECC037F-C1B0-49BF-9E94-311F6CCA8D27}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
			public const string HideFromNavigation = "Hide From Navigation";
			public const string NavigationTitle = "Navigation Title";
			public const string ContentTitle = "Content Title";
			public const string ContentBody = "Content Body";
			public const string ContentImage = "Content Image";
			public const string MetaDescription = "Meta Description";
			public const string MetaKeywords = "Meta Keywords";
			public const string MetaTitle = "Meta Title";
			public const string ProductID = "Product ID";
		}

		public static partial class IndexFieldNames
		{
			public const string HideFromNavigation = "hide_from_navigation";
			public const string NavigationTitle = "navigation_title";
			public const string ContentTitle = "content_title";
			public const string ContentBody = "content_body";
			public const string ContentImage = "content_image";
			public const string MetaDescription = "meta_description";
			public const string MetaKeywords = "meta_keywords";
			public const string MetaTitle = "meta_title";
			public const string ProductID = "product_id";
		}

		#endregion
	}
}

#endregion
#region Content Title (UserDefined)

namespace FortisDemo.Model.Templates.UserDefined
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Content Title</para>
	/// <para>ID: {352C79B1-B75C-4918-9B5F-FEE4BFFA5642}</para>
	/// <para>/sitecore/templates/User Defined/Content Templates/Content Title</para>
	/// </summary>
	[TemplateMapping(ContentTitleItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface IContentTitleItem : ISitecoreItem 
	{		
		/// <summary>
		/// <para>Template: Content Title</para><para>Field: ContentTitle</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(ContentTitleItem.IndexFieldNames.ContentTitle)]
		ITextFieldWrapper ContentTitle { get; }

		/// <summary>
		/// <para>Template: Content Title</para><para>Field: ContentTitle</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(ContentTitleItem.IndexFieldNames.ContentTitle)]
		string ContentTitleValue { get; }
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/User Defined/Content Templates/Content Title</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, ContentTitleItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(ContentTitleItem.Constants.TemplateIdStr, "")]
	public partial class ContentTitleItem : SitecoreItem, IContentTitleItem
	{
		private Item _item = null;

		public ContentTitleItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public ContentTitleItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public ContentTitleItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public ContentTitleItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

		/// <summary><para>Template: Content Title</para><para>Field: ContentTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ContentTitle)]
		public virtual ITextFieldWrapper ContentTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.ContentTitle, IndexFieldNames.ContentTitle); }
		}

		/// <summary><para>Template: Content Title</para><para>Field: ContentTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ContentTitle)]
		public string ContentTitleValue
		{
			get { return ContentTitle.Value; }
		}
	
		#region ContentTitleItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{352C79B1-B75C-4918-9B5F-FEE4BFFA5642}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
			public const string ContentTitle = "Content Title";
		}

		public static partial class IndexFieldNames
		{
			public const string ContentTitle = "content_title";
		}

		#endregion
	}
}

#endregion
#region Content Body (UserDefined)

namespace FortisDemo.Model.Templates.UserDefined
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Content Body</para>
	/// <para>ID: {4210390C-AD6B-451E-ABDB-7F4F04377778}</para>
	/// <para>/sitecore/templates/User Defined/Content Templates/Content Body</para>
	/// </summary>
	[TemplateMapping(ContentBodyItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface IContentBodyItem : ISitecoreItem 
	{		
		/// <summary>
		/// <para>Template: Content Body</para><para>Field: ContentBody</para><para>Data type: Rich Text</para>
		/// </summary>
		[IndexField(ContentBodyItem.IndexFieldNames.ContentBody)]
		IRichTextFieldWrapper ContentBody { get; }

		/// <summary>
		/// <para>Template: Content Body</para><para>Field: ContentBody</para><para>Data type: Rich Text</para>
		/// </summary>
		[IndexField(ContentBodyItem.IndexFieldNames.ContentBody)]
		string ContentBodyValue { get; }
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/User Defined/Content Templates/Content Body</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, ContentBodyItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(ContentBodyItem.Constants.TemplateIdStr, "")]
	public partial class ContentBodyItem : SitecoreItem, IContentBodyItem
	{
		private Item _item = null;

		public ContentBodyItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public ContentBodyItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public ContentBodyItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public ContentBodyItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

		/// <summary><para>Template: Content Body</para><para>Field: ContentBody</para><para>Data type: Rich Text</para></summary>
		[IndexField(IndexFieldNames.ContentBody)]
		public virtual IRichTextFieldWrapper ContentBody
		{
			get { return GetField<RichTextFieldWrapper>(FieldNames.ContentBody, IndexFieldNames.ContentBody); }
		}

		/// <summary><para>Template: Content Body</para><para>Field: ContentBody</para><para>Data type: Rich Text</para></summary>
		[IndexField(IndexFieldNames.ContentBody)]
		public string ContentBodyValue
		{
			get { return ContentBody.Value; }
		}
	
		#region ContentBodyItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{4210390C-AD6B-451E-ABDB-7F4F04377778}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
			public const string ContentBody = "Content Body";
		}

		public static partial class IndexFieldNames
		{
			public const string ContentBody = "content_body";
		}

		#endregion
	}
}

#endregion
#region Content Image (UserDefined)

namespace FortisDemo.Model.Templates.UserDefined
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Content Image</para>
	/// <para>ID: {54A1B008-7584-4260-8571-2645F3C5786D}</para>
	/// <para>/sitecore/templates/User Defined/Content Templates/Content Image</para>
	/// </summary>
	[TemplateMapping(ContentImageItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface IContentImageItem : ISitecoreItem 
	{		
		/// <summary>
		/// <para>Template: Content Image</para><para>Field: ContentImage</para><para>Data type: Image</para>
		/// </summary>
		IImageFieldWrapper ContentImage { get; }
		string ContentImageValue { get; }
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/User Defined/Content Templates/Content Image</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, ContentImageItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(ContentImageItem.Constants.TemplateIdStr, "")]
	public partial class ContentImageItem : SitecoreItem, IContentImageItem
	{
		private Item _item = null;

		public ContentImageItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public ContentImageItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public ContentImageItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public ContentImageItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

		/// <summary><para>Template: Content Image</para><para>Field: ContentImage</para><para>Data type: Image</para></summary>
		public virtual IImageFieldWrapper ContentImage
		{
			get { return GetField<ImageFieldWrapper>(FieldNames.ContentImage); }
		}

		/// <summary><para>Template: Content Image</para><para>Field: ContentImage</para><para>Data type: Image</para></summary>
		public string ContentImageValue
		{
			get { return ContentImage.Value; }
		}
	
		#region ContentImageItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{54A1B008-7584-4260-8571-2645F3C5786D}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
			public const string ContentImage = "Content Image";
		}

		public static partial class IndexFieldNames
		{
			public const string ContentImage = "content_image";
		}

		#endregion
	}
}

#endregion
#region Content Page (UserDefined)

namespace FortisDemo.Model.Templates.UserDefined
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Content Page</para>
	/// <para>ID: {8DAC2938-20EC-4CB0-BA4E-0DE432AA369E}</para>
	/// <para>/sitecore/templates/User Defined/Page Types/Content Page</para>
	/// </summary>
	[TemplateMapping(ContentPageItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface IContentPageItem : ISitecoreItem , FortisDemo.Model.Templates.UserDefined.INavigationItem, FortisDemo.Model.Templates.UserDefined.IContentTitleItem, FortisDemo.Model.Templates.UserDefined.IContentBodyItem, FortisDemo.Model.Templates.UserDefined.IContentImageItem, FortisDemo.Model.Templates.UserDefined.ISeoItem
	{		
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/User Defined/Page Types/Content Page</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, ContentPageItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(ContentPageItem.Constants.TemplateIdStr, "")]
	public partial class ContentPageItem : SitecoreItem, IContentPageItem
	{
		private Item _item = null;

		public ContentPageItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public ContentPageItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public ContentPageItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public ContentPageItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

		/// <summary><para>Template: Content Page</para><para>Field: HideFromNavigation</para><para>Data type: Checkbox</para></summary>
		[IndexField(IndexFieldNames.HideFromNavigation)]
		public virtual IBooleanFieldWrapper HideFromNavigation
		{
			get { return GetField<BooleanFieldWrapper>(FieldNames.HideFromNavigation, IndexFieldNames.HideFromNavigation); }
		}

		/// <summary><para>Template: Content Page</para><para>Field: HideFromNavigation</para><para>Data type: Checkbox</para></summary>
		[IndexField(IndexFieldNames.HideFromNavigation)]
		public bool HideFromNavigationValue
		{
			get { return HideFromNavigation.Value; }
		}
		/// <summary><para>Template: Content Page</para><para>Field: NavigationTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.NavigationTitle)]
		public virtual ITextFieldWrapper NavigationTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.NavigationTitle, IndexFieldNames.NavigationTitle); }
		}

		/// <summary><para>Template: Content Page</para><para>Field: NavigationTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.NavigationTitle)]
		public string NavigationTitleValue
		{
			get { return NavigationTitle.Value; }
		}
		/// <summary><para>Template: Content Page</para><para>Field: ContentTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ContentTitle)]
		public virtual ITextFieldWrapper ContentTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.ContentTitle, IndexFieldNames.ContentTitle); }
		}

		/// <summary><para>Template: Content Page</para><para>Field: ContentTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ContentTitle)]
		public string ContentTitleValue
		{
			get { return ContentTitle.Value; }
		}
		/// <summary><para>Template: Content Page</para><para>Field: ContentBody</para><para>Data type: Rich Text</para></summary>
		[IndexField(IndexFieldNames.ContentBody)]
		public virtual IRichTextFieldWrapper ContentBody
		{
			get { return GetField<RichTextFieldWrapper>(FieldNames.ContentBody, IndexFieldNames.ContentBody); }
		}

		/// <summary><para>Template: Content Page</para><para>Field: ContentBody</para><para>Data type: Rich Text</para></summary>
		[IndexField(IndexFieldNames.ContentBody)]
		public string ContentBodyValue
		{
			get { return ContentBody.Value; }
		}
		/// <summary><para>Template: Content Page</para><para>Field: ContentImage</para><para>Data type: Image</para></summary>
		public virtual IImageFieldWrapper ContentImage
		{
			get { return GetField<ImageFieldWrapper>(FieldNames.ContentImage); }
		}

		/// <summary><para>Template: Content Page</para><para>Field: ContentImage</para><para>Data type: Image</para></summary>
		public string ContentImageValue
		{
			get { return ContentImage.Value; }
		}
		/// <summary><para>Template: Content Page</para><para>Field: MetaDescription</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaDescription)]
		public virtual ITextFieldWrapper MetaDescription
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaDescription, IndexFieldNames.MetaDescription); }
		}

		/// <summary><para>Template: Content Page</para><para>Field: MetaDescription</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaDescription)]
		public string MetaDescriptionValue
		{
			get { return MetaDescription.Value; }
		}
		/// <summary><para>Template: Content Page</para><para>Field: MetaKeywords</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaKeywords)]
		public virtual ITextFieldWrapper MetaKeywords
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaKeywords, IndexFieldNames.MetaKeywords); }
		}

		/// <summary><para>Template: Content Page</para><para>Field: MetaKeywords</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaKeywords)]
		public string MetaKeywordsValue
		{
			get { return MetaKeywords.Value; }
		}
		/// <summary><para>Template: Content Page</para><para>Field: MetaTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaTitle)]
		public virtual ITextFieldWrapper MetaTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaTitle, IndexFieldNames.MetaTitle); }
		}

		/// <summary><para>Template: Content Page</para><para>Field: MetaTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaTitle)]
		public string MetaTitleValue
		{
			get { return MetaTitle.Value; }
		}
	
		#region ContentPageItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{8DAC2938-20EC-4CB0-BA4E-0DE432AA369E}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
			public const string HideFromNavigation = "Hide From Navigation";
			public const string NavigationTitle = "Navigation Title";
			public const string ContentTitle = "Content Title";
			public const string ContentBody = "Content Body";
			public const string ContentImage = "Content Image";
			public const string MetaDescription = "Meta Description";
			public const string MetaKeywords = "Meta Keywords";
			public const string MetaTitle = "Meta Title";
		}

		public static partial class IndexFieldNames
		{
			public const string HideFromNavigation = "hide_from_navigation";
			public const string NavigationTitle = "navigation_title";
			public const string ContentTitle = "content_title";
			public const string ContentBody = "content_body";
			public const string ContentImage = "content_image";
			public const string MetaDescription = "meta_description";
			public const string MetaKeywords = "meta_keywords";
			public const string MetaTitle = "meta_title";
		}

		#endregion
	}
}

#endregion
#region Seo (UserDefined)

namespace FortisDemo.Model.Templates.UserDefined
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Seo</para>
	/// <para>ID: {A7CB2CD5-C4B1-46A6-B92F-4EF8185B45EC}</para>
	/// <para>/sitecore/templates/User Defined/Content Templates/Seo</para>
	/// </summary>
	[TemplateMapping(SeoItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface ISeoItem : ISitecoreItem 
	{		
		/// <summary>
		/// <para>Template: Seo</para><para>Field: MetaDescription</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(SeoItem.IndexFieldNames.MetaDescription)]
		ITextFieldWrapper MetaDescription { get; }

		/// <summary>
		/// <para>Template: Seo</para><para>Field: MetaDescription</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(SeoItem.IndexFieldNames.MetaDescription)]
		string MetaDescriptionValue { get; }
		/// <summary>
		/// <para>Template: Seo</para><para>Field: MetaKeywords</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(SeoItem.IndexFieldNames.MetaKeywords)]
		ITextFieldWrapper MetaKeywords { get; }

		/// <summary>
		/// <para>Template: Seo</para><para>Field: MetaKeywords</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(SeoItem.IndexFieldNames.MetaKeywords)]
		string MetaKeywordsValue { get; }
		/// <summary>
		/// <para>Template: Seo</para><para>Field: MetaTitle</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(SeoItem.IndexFieldNames.MetaTitle)]
		ITextFieldWrapper MetaTitle { get; }

		/// <summary>
		/// <para>Template: Seo</para><para>Field: MetaTitle</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(SeoItem.IndexFieldNames.MetaTitle)]
		string MetaTitleValue { get; }
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/User Defined/Content Templates/Seo</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, SeoItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(SeoItem.Constants.TemplateIdStr, "")]
	public partial class SeoItem : SitecoreItem, ISeoItem
	{
		private Item _item = null;

		public SeoItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public SeoItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public SeoItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public SeoItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

		/// <summary><para>Template: Seo</para><para>Field: MetaDescription</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaDescription)]
		public virtual ITextFieldWrapper MetaDescription
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaDescription, IndexFieldNames.MetaDescription); }
		}

		/// <summary><para>Template: Seo</para><para>Field: MetaDescription</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaDescription)]
		public string MetaDescriptionValue
		{
			get { return MetaDescription.Value; }
		}
		/// <summary><para>Template: Seo</para><para>Field: MetaKeywords</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaKeywords)]
		public virtual ITextFieldWrapper MetaKeywords
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaKeywords, IndexFieldNames.MetaKeywords); }
		}

		/// <summary><para>Template: Seo</para><para>Field: MetaKeywords</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaKeywords)]
		public string MetaKeywordsValue
		{
			get { return MetaKeywords.Value; }
		}
		/// <summary><para>Template: Seo</para><para>Field: MetaTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaTitle)]
		public virtual ITextFieldWrapper MetaTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.MetaTitle, IndexFieldNames.MetaTitle); }
		}

		/// <summary><para>Template: Seo</para><para>Field: MetaTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.MetaTitle)]
		public string MetaTitleValue
		{
			get { return MetaTitle.Value; }
		}
	
		#region SeoItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{A7CB2CD5-C4B1-46A6-B92F-4EF8185B45EC}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
			public const string MetaDescription = "Meta Description";
			public const string MetaKeywords = "Meta Keywords";
			public const string MetaTitle = "Meta Title";
		}

		public static partial class IndexFieldNames
		{
			public const string MetaDescription = "meta_description";
			public const string MetaKeywords = "meta_keywords";
			public const string MetaTitle = "meta_title";
		}

		#endregion
	}
}

#endregion
#region Product Repository (UserDefined)

namespace FortisDemo.Model.Templates.UserDefined
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Product Repository</para>
	/// <para>ID: {ACB06EF6-A3E2-47BE-BFCD-23CF289D188B}</para>
	/// <para>/sitecore/templates/User Defined/Products/Product Repository</para>
	/// </summary>
	[TemplateMapping(ProductRepositoryItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface IProductRepositoryItem : ISitecoreItem 
	{		
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/User Defined/Products/Product Repository</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, ProductRepositoryItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(ProductRepositoryItem.Constants.TemplateIdStr, "")]
	public partial class ProductRepositoryItem : SitecoreItem, IProductRepositoryItem
	{
		private Item _item = null;

		public ProductRepositoryItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public ProductRepositoryItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public ProductRepositoryItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public ProductRepositoryItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

	
		#region ProductRepositoryItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{ACB06EF6-A3E2-47BE-BFCD-23CF289D188B}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
		}

		public static partial class IndexFieldNames
		{
		}

		#endregion
	}
}

#endregion
#region Wildcard Route (Custom)

namespace FortisDemo.Model.Templates.Custom
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Wildcard Route</para>
	/// <para>ID: {B4C339CC-57FD-4FF2-ACBA-120B72C5FE78}</para>
	/// <para>/sitecore/templates/Wildcards/Wildcard Route</para>
	/// </summary>
	[TemplateMapping(WildcardRouteItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface IWildcardRouteItem : ISitecoreItem 
	{		
		/// <summary>
		/// <para>Template: Wildcard Route</para><para>Field: ItemResolvingRules</para><para>Data type: Name Value List</para>
		/// </summary>
		ITextFieldWrapper ItemResolvingRules { get; }
		string ItemResolvingRulesValue { get; }
		/// <summary>
		/// <para>Template: Wildcard Route</para><para>Field: ItemSearchRootNode</para><para>Data type: Internal Link</para>
		/// </summary>
		ITextFieldWrapper ItemSearchRootNode { get; }
		string ItemSearchRootNodeValue { get; }
		/// <summary>
		/// <para>Template: Wildcard Route</para><para>Field: ItemTemplates</para><para>Data type: TreelistEx</para>
		/// </summary>
		[IndexField(WildcardRouteItem.IndexFieldNames.ItemTemplates)]
		IListFieldWrapper ItemTemplates { get; }

		/// <summary>
		/// <para>Template: Wildcard Route</para><para>Field: ItemTemplates</para><para>Data type: TreelistEx</para>
		/// </summary>
		[IndexField(WildcardRouteItem.IndexFieldNames.ItemTemplates)]
		IEnumerable<Guid> ItemTemplatesValue { get; }
		/// <summary>
		/// <para>Template: Wildcard Route</para><para>Field: UrlGenerationRules</para><para>Data type: Name Value List</para>
		/// </summary>
		ITextFieldWrapper UrlGenerationRules { get; }
		string UrlGenerationRulesValue { get; }
		/// <summary>
		/// <para>Template: Wildcard Route</para><para>Field: WildcardItems</para><para>Data type: TreelistEx</para>
		/// </summary>
		[IndexField(WildcardRouteItem.IndexFieldNames.WildcardItems)]
		IListFieldWrapper WildcardItems { get; }

		/// <summary>
		/// <para>Template: Wildcard Route</para><para>Field: WildcardItems</para><para>Data type: TreelistEx</para>
		/// </summary>
		[IndexField(WildcardRouteItem.IndexFieldNames.WildcardItems)]
		IEnumerable<Guid> WildcardItemsValue { get; }
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/Wildcards/Wildcard Route</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, WildcardRouteItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(WildcardRouteItem.Constants.TemplateIdStr, "")]
	public partial class WildcardRouteItem : SitecoreItem, IWildcardRouteItem
	{
		private Item _item = null;

		public WildcardRouteItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public WildcardRouteItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public WildcardRouteItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public WildcardRouteItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

		/// <summary><para>Template: Wildcard Route</para><para>Field: ItemResolvingRules</para><para>Data type: Name Value List</para></summary>
		public virtual ITextFieldWrapper ItemResolvingRules
		{
			get { return GetField<TextFieldWrapper>(FieldNames.ItemResolvingRules); }
		}

		/// <summary><para>Template: Wildcard Route</para><para>Field: ItemResolvingRules</para><para>Data type: Name Value List</para></summary>
		public string ItemResolvingRulesValue
		{
			get { return ItemResolvingRules.Value; }
		}
		/// <summary><para>Template: Wildcard Route</para><para>Field: ItemSearchRootNode</para><para>Data type: Internal Link</para></summary>
		public virtual ITextFieldWrapper ItemSearchRootNode
		{
			get { return GetField<TextFieldWrapper>(FieldNames.ItemSearchRootNode); }
		}

		/// <summary><para>Template: Wildcard Route</para><para>Field: ItemSearchRootNode</para><para>Data type: Internal Link</para></summary>
		public string ItemSearchRootNodeValue
		{
			get { return ItemSearchRootNode.Value; }
		}
		/// <summary><para>Template: Wildcard Route</para><para>Field: ItemTemplates</para><para>Data type: TreelistEx</para></summary>
		[IndexField(IndexFieldNames.ItemTemplates)]
		public virtual IListFieldWrapper ItemTemplates
		{
			get { return GetField<ListFieldWrapper>(FieldNames.ItemTemplates, IndexFieldNames.ItemTemplates); }
		}

		/// <summary><para>Template: Wildcard Route</para><para>Field: ItemTemplates</para><para>Data type: TreelistEx</para></summary>
		[IndexField(IndexFieldNames.ItemTemplates)]
		public IEnumerable<Guid> ItemTemplatesValue
		{
			get { return ItemTemplates.Value; }
		}
		/// <summary><para>Template: Wildcard Route</para><para>Field: UrlGenerationRules</para><para>Data type: Name Value List</para></summary>
		public virtual ITextFieldWrapper UrlGenerationRules
		{
			get { return GetField<TextFieldWrapper>(FieldNames.UrlGenerationRules); }
		}

		/// <summary><para>Template: Wildcard Route</para><para>Field: UrlGenerationRules</para><para>Data type: Name Value List</para></summary>
		public string UrlGenerationRulesValue
		{
			get { return UrlGenerationRules.Value; }
		}
		/// <summary><para>Template: Wildcard Route</para><para>Field: WildcardItems</para><para>Data type: TreelistEx</para></summary>
		[IndexField(IndexFieldNames.WildcardItems)]
		public virtual IListFieldWrapper WildcardItems
		{
			get { return GetField<ListFieldWrapper>(FieldNames.WildcardItems, IndexFieldNames.WildcardItems); }
		}

		/// <summary><para>Template: Wildcard Route</para><para>Field: WildcardItems</para><para>Data type: TreelistEx</para></summary>
		[IndexField(IndexFieldNames.WildcardItems)]
		public IEnumerable<Guid> WildcardItemsValue
		{
			get { return WildcardItems.Value; }
		}
	
		#region WildcardRouteItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{B4C339CC-57FD-4FF2-ACBA-120B72C5FE78}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
			public const string ItemResolvingRules = "Item Resolving Rules";
			public const string ItemSearchRootNode = "Item Search Root Node";
			public const string ItemTemplates = "Item Templates";
			public const string UrlGenerationRules = "Url Generation Rules";
			public const string WildcardItems = "Wildcard Items";
		}

		public static partial class IndexFieldNames
		{
			public const string ItemResolvingRules = "item_resolving_rules";
			public const string ItemSearchRootNode = "item_search_root_node";
			public const string ItemTemplates = "item_templates";
			public const string UrlGenerationRules = "url_generation_rules";
			public const string WildcardItems = "wildcard_items";
		}

		#endregion
	}
}

#endregion
#region Product Data (UserDefined)

namespace FortisDemo.Model.Templates.UserDefined
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Product Data</para>
	/// <para>ID: {BE5BDF0F-A6C6-43D8-8633-D7BDA773DF7A}</para>
	/// <para>/sitecore/templates/User Defined/Products/Product Data</para>
	/// </summary>
	[TemplateMapping(ProductDataItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface IProductDataItem : ISitecoreItem 
	{		
		/// <summary>
		/// <para>Template: Product Data</para><para>Field: ProductID</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(ProductDataItem.IndexFieldNames.ProductID)]
		ITextFieldWrapper ProductID { get; }

		/// <summary>
		/// <para>Template: Product Data</para><para>Field: ProductID</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(ProductDataItem.IndexFieldNames.ProductID)]
		string ProductIDValue { get; }
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/User Defined/Products/Product Data</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, ProductDataItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(ProductDataItem.Constants.TemplateIdStr, "")]
	public partial class ProductDataItem : SitecoreItem, IProductDataItem
	{
		private Item _item = null;

		public ProductDataItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public ProductDataItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public ProductDataItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public ProductDataItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

		/// <summary><para>Template: Product Data</para><para>Field: ProductID</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ProductID)]
		public virtual ITextFieldWrapper ProductID
		{
			get { return GetField<TextFieldWrapper>(FieldNames.ProductID, IndexFieldNames.ProductID); }
		}

		/// <summary><para>Template: Product Data</para><para>Field: ProductID</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.ProductID)]
		public string ProductIDValue
		{
			get { return ProductID.Value; }
		}
	
		#region ProductDataItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{BE5BDF0F-A6C6-43D8-8633-D7BDA773DF7A}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
			public const string ProductID = "Product ID";
		}

		public static partial class IndexFieldNames
		{
			public const string ProductID = "product_id";
		}

		#endregion
	}
}

#endregion
#region Navigation (UserDefined)

namespace FortisDemo.Model.Templates.UserDefined
{
	using global::System;
	using global::System.Collections.Generic;
	using global::Fortis.Model;
	using global::Fortis.Model.Fields;
	using global::Fortis.Providers;

	/// <summary>
	/// <para>Template interface</para>
	/// <para>Template: Navigation</para>
	/// <para>ID: {F80BAA4D-5F8B-40EA-BE43-20D649B2C92D}</para>
	/// <para>/sitecore/templates/User Defined/Content Templates/Navigation</para>
	/// </summary>
	[TemplateMapping(NavigationItem.Constants.TemplateIdStr, "InterfaceMap")]
	public partial interface INavigationItem : ISitecoreItem 
	{		
		/// <summary>
		/// <para>Template: Navigation</para><para>Field: HideFromNavigation</para><para>Data type: Checkbox</para>
		/// </summary>
		[IndexField(NavigationItem.IndexFieldNames.HideFromNavigation)]
		IBooleanFieldWrapper HideFromNavigation { get; }

		/// <summary>
		/// <para>Template: Navigation</para><para>Field: HideFromNavigation</para><para>Data type: Checkbox</para>
		/// </summary>
		[IndexField(NavigationItem.IndexFieldNames.HideFromNavigation)]
		bool HideFromNavigationValue { get; }
		/// <summary>
		/// <para>Template: Navigation</para><para>Field: NavigationTitle</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(NavigationItem.IndexFieldNames.NavigationTitle)]
		ITextFieldWrapper NavigationTitle { get; }

		/// <summary>
		/// <para>Template: Navigation</para><para>Field: NavigationTitle</para><para>Data type: Single-Line Text</para>
		/// </summary>
		[IndexField(NavigationItem.IndexFieldNames.NavigationTitle)]
		string NavigationTitleValue { get; }
	}

	/// <summary>
	/// <para>Template class</para><para>/sitecore/templates/User Defined/Content Templates/Navigation</para>
	/// </summary>
	[PredefinedQuery("TemplateId", ComparisonType.Equal, NavigationItem.Constants.TemplateIdStr, typeof(Guid))]
	[TemplateMapping(NavigationItem.Constants.TemplateIdStr, "")]
	public partial class NavigationItem : SitecoreItem, INavigationItem
	{
		private Item _item = null;

		public NavigationItem(ISpawnProvider spawnProvider) : base(null, spawnProvider) { }

		public NavigationItem(Guid id, ISpawnProvider spawnProvider) : base(id, spawnProvider) { }

		public NavigationItem(Guid id, Dictionary<string, object> lazyFields, ISpawnProvider spawnProvider) : base(id, lazyFields, spawnProvider) { }

		public NavigationItem(Item item, ISpawnProvider spawnProvider) : base(item, spawnProvider)
		{
			_item = item;
		}

		/// <summary><para>Template: Navigation</para><para>Field: HideFromNavigation</para><para>Data type: Checkbox</para></summary>
		[IndexField(IndexFieldNames.HideFromNavigation)]
		public virtual IBooleanFieldWrapper HideFromNavigation
		{
			get { return GetField<BooleanFieldWrapper>(FieldNames.HideFromNavigation, IndexFieldNames.HideFromNavigation); }
		}

		/// <summary><para>Template: Navigation</para><para>Field: HideFromNavigation</para><para>Data type: Checkbox</para></summary>
		[IndexField(IndexFieldNames.HideFromNavigation)]
		public bool HideFromNavigationValue
		{
			get { return HideFromNavigation.Value; }
		}
		/// <summary><para>Template: Navigation</para><para>Field: NavigationTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.NavigationTitle)]
		public virtual ITextFieldWrapper NavigationTitle
		{
			get { return GetField<TextFieldWrapper>(FieldNames.NavigationTitle, IndexFieldNames.NavigationTitle); }
		}

		/// <summary><para>Template: Navigation</para><para>Field: NavigationTitle</para><para>Data type: Single-Line Text</para></summary>
		[IndexField(IndexFieldNames.NavigationTitle)]
		public string NavigationTitleValue
		{
			get { return NavigationTitle.Value; }
		}
	
		#region NavigationItem Constants 

		public static partial class Constants
		{
			public const string TemplateIdStr = "{F80BAA4D-5F8B-40EA-BE43-20D649B2C92D}";
			public static Guid TemplateId = new Guid(TemplateIdStr);
		}

		public static partial class FieldNames
		{
			public const string HideFromNavigation = "Hide From Navigation";
			public const string NavigationTitle = "Navigation Title";
		}

		public static partial class IndexFieldNames
		{
			public const string HideFromNavigation = "hide_from_navigation";
			public const string NavigationTitle = "navigation_title";
		}

		#endregion
	}
}

#endregion
