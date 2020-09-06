using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
	[Table("AccountsHistorys", Schema = "dbo")]
	public class AccountsHistory : BaseModel
	{
		[Column("IdAccounts")]
		public int IdAccounts { get; set; }

		[Column("Moment")]
		public DateTime Moment { get; set; }

		[Column("Event")]
		public int Event { get; set; }

		[Column("Summa")]
		public float Summa { get; set; }

		[Column("IdUsers")]
		public int IdUsers { get; set; }

	}
}