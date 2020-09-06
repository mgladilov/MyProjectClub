using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
	[Table("AccountsDiscounts", Schema = "dbo")]
	public class AccountsDiscount : BaseModel
	{
		[Column("Summary")]
		public float Summary { get; set; }

		[Column("Discount")]
		public int Discount { get; set; }
	}
}