using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;

namespace FortisDemo.Model
{
	public partial interface ISitecoreItem
	{
		[TypeConverter(typeof(IndexFieldEnumerableConverter))]
		[IndexField("_path")]
		IEnumerable<Guid> Paths { get; set; }
	}
}
