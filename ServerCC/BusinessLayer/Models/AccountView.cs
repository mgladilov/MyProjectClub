namespace BusinessLayer.Models
{
	public class AccountView : BaseModel
	{
		public string Name { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string Address { get; set; }

		public bool IsBlocked { get; set; }

		public bool IsPrivileged { get; set; }

		public int PrivilegedDiscount { get; set; }

		public int ZeroBalance { get; set; }

		public double Balance { get; set; }

		public double Summary { get; set; }

		public string Remark { get; set; }
	}
}