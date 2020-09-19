using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("Accounts", Schema = "dbo")]
	public class Account : BaseEntity
	{
		[Column("Name")]
		public string Name { get; set; }

		[Column("Password")]
		public string Password { get; set; }

		[Column("Email")]
		public string Email { get; set; }

		[Column("Phone")]
		public string Phone { get; set; }

		[Column("Address")]
		public string Address { get; set; }

		[Column("IsBlocked")]
		public bool IsBlocked { get; set; }

		[Column("IsPrivileged")]
		public bool IsPrivileged { get; set; }

		[Column("PrivilegedDiscount")]
		public int PrivilegedDiscount { get; set; }

		[Column("ZeroBalance")]
		public int ZeroBalance { get; set; }

		[Column("Balance")]
		public double Balance { get; set; }

		[Column("Summary")]
		public double Summary { get; set; }

		[Column("Remark")]
		public string Remark { get; set; }

	}
}