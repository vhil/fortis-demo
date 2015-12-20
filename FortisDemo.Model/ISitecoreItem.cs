using Fortis.Model.Fields;
using Sitecore.ContentSearch;

namespace FortisDemo.Model
{
	public partial interface ISitecoreItem
	{
		[IndexField("__smallupdateddate")]
		IDateTimeFieldWrapper UpdatedDate { get; }

		[IndexField("__smallcreateddate")]
		IDateTimeFieldWrapper CreatedDate { get; }
	}
}
