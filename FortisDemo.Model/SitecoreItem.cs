using Sitecore.Data;

namespace FortisDemo.Model
{
	public partial class SitecoreItem : ISitecoreItem
	{
		public override string ToString()
		{
			return string.Format(
				"{0} ({1}#{2}), id: {3}",
				this.Name,
				this.LanguageName,
				this.DatabaseName,
				new ID(ItemID));
		}

		public override bool Equals(object obj)
		{
			var p = obj as ISitecoreItem;

			return this.Equals(p);
		}

		public bool Equals(ISitecoreItem p)
		{
			if (p == null)
			{
				return false;
			}

			return this.ItemID == p.ItemID;
		}

		public override int GetHashCode()
		{
			return ItemID.GetHashCode();
		}
	}
}
