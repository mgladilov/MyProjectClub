using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
	[Table("JournalOpers", Schema = "dbo")]
	public class JournalOper : BaseModel
	{
		[Column("Summa")]
		public float Summa { get; set; }

		[Column("Moment")]
		public DateTime Moment { get; set; }

		[Column("IdUsers")]
		public int IdUsers { get; set; }

		[Column("Remark")]
		public string Remark { get; set; }
	}
}