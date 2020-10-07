using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("TariffIntervals", Schema = "dbo")]
	public class TariffInterval : BaseEntity
	{
		[Column("IdGroup")]
		public int IdGroup { get; set; }

		[Column("Name")]
		public string Name { get; set; }

		[Column("Start")]
		public TimeSpan Start { get; set; }

		[Column("Stop")]
		public TimeSpan Stop { get; set; }

		[Column("Cost")]
		public double Cost { get; set; }

		[Column("IsPacket")]
		public bool IsPacket { get; set; }

		[Column("IsNonFixed")]
		public bool IsNonFixed { get; set; }

		[Column("Condition")]
		public string Condition { get; set; }

		[Column("DaysOfWeek")]
		public DayOfWeek DaysOfWeek { get; set; }

		[ForeignKey(nameof(IdGroup))]
		public ComputerGroup ComputerGroup { get; set; }
	}
}