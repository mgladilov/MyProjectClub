using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("AccountsDiscounts", Schema = "dbo")]
	public class AccountsDiscount : BaseEntity
	{
		[Column("Summary")]
		public float Summary { get; set; }

		[Column("Discount")]
		public int Discount { get; set; }
	}
}