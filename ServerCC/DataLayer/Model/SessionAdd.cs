using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
	[Table("SessionAdd", Schema = "dbo")]
	public class SessionAdd : BaseModel
	{
		[Column("IdSessionsAdd")]
		public int IdSessionsAdd { get; set; }

		[Column("ActionType")]
		public int ActionType { get; set; }

		[Column("Moment")]
		public DateTime Moment { get; set; }

		[Column("Summa")]
		public float Summa { get; set; }
	}
}