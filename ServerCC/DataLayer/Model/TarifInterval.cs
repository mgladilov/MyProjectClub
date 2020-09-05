using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("TarifIntervals", Schema = "dbo")]
	public class TarifInterval : BaseEntity
	{
		[Column("IdTarifs")]
		public int IdTarifs { get; set; }

		[Column("Name")]
		public string Name { get; set; }

		[Column("Start")]
		public DateTime Start { get; set; }

		[Column("Stop")]
		public DateTime Stop { get; set; }

		[Column("Cost")]
		public float Cost { get; set; }

		[Column("IsPacket")]
		public int IsPacket { get; set; }

		[Column("Condition")]
		public string Condition { get; set; }

		[Column("DaysOfWeek")]
		public string DaysOfWeek { get; set; }
	}
}