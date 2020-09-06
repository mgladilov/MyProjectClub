using System;

namespace BusinessLayer.Models
{
	public class AccountsHistoryView : BaseModel
	{
		public int IdAccounts { get; set; }

		public DateTime Moment { get; set; }

		public int Event { get; set; }

		public float Summa { get; set; }

		public int IdUsers { get; set; }
	}
}