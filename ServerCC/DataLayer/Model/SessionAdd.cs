using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("SessionAdd", Schema = "dbo")]
	public class SessionAdd : BaseEntity
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