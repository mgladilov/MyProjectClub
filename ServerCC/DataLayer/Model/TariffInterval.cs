using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace DataLayer.Model
{
	[Table("TariffIntervals", Schema = "dbo")]
	public class TariffInterval : BaseEntity
	{
		private DayOfWeek _daysOfWeek;

		[Column("IdGroup")]
		public int IdGroup { get; set; }

		[Column("Name")]
		public string Name { get; set; }

		[Column("Start")]
		public DateTime Start { get; set; }

		[Column("Stop")]
		public DateTime Stop { get; set; }

		[Column("Cost")]
		public double Cost { get; set; }

		[Column("IsPacket")]
		public bool IsPacket { get; set; }

		[Column("Condition")]
		public string Condition { get; set; }

		[Column("DaysOfWeek")]
		public DayOfWeek DaysOfWeek
		{
			get => _daysOfWeek;
			set
			{
				if (value == _daysOfWeek) return;
				_daysOfWeek = value;
				OnPropertyChanged();
			}
		}

		[ForeignKey(nameof(IdGroup))]
		public ComputerGroup ComputerGroup { get; set; }

		#region DayOfWeek

		private void MergeDays(DayOfWeek day)
		{
			if (!DaysOfWeek.HasFlag(day))
				DaysOfWeek |= day;
			else
				DaysOfWeek &= ~day;
		}

		[NotMapped]
		public bool IsMonday
		{
			get { return DaysOfWeek.HasFlag(DayOfWeek.Monday); }
			set { MergeDays(DayOfWeek.Monday); }
		}

		[NotMapped]
		public bool IsTuesday
		{
			get { return DaysOfWeek.HasFlag(DayOfWeek.Tuesday); }
			set { MergeDays(DayOfWeek.Tuesday); }
		}
		[NotMapped]
		public bool IsWednesday
		{
			get { return DaysOfWeek.HasFlag(DayOfWeek.Wednesday); }
			set { MergeDays(DayOfWeek.Wednesday); }
		}
		[NotMapped]
		public bool IsThursday
		{
			get { return DaysOfWeek.HasFlag(DayOfWeek.Thursday); }
			set { MergeDays(DayOfWeek.Thursday); }
		}
		[NotMapped]
		public bool IsFriday
		{
			get { return DaysOfWeek.HasFlag(DayOfWeek.Friday); }
			set { MergeDays(DayOfWeek.Friday); }
		}
		[NotMapped]
		public bool IsSaturday
		{
			get { return DaysOfWeek.HasFlag(DayOfWeek.Saturday); }
			set { MergeDays(DayOfWeek.Saturday); }
		}
		[NotMapped]
		public bool IsSunday
		{
			get { return DaysOfWeek.HasFlag(DayOfWeek.Sunday); }
			set { MergeDays(DayOfWeek.Sunday); }
		}

		#endregion
		
	}

	[Flags]
	public enum DayOfWeek : int
	{
		//[Description("нет")]
		//None = 0,
		[Description("пн")]
		Monday = 1,
		[Description("вт")]
		Tuesday = 2,
		[Description("ср")]
		Wednesday = 4,
		[Description("чт")]
		Thursday = 8,
		[Description("пт")]
		Friday = 16,
		[Description("сб")]
		Saturday = 32,
		[Description("вс")]
		Sunday = 64,
	}
}