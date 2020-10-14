using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
	public class TariffIntervalView : BaseModel
	{
		private ComputerGroupView _computerGroup;
		private DayOfWeek _daysOfWeek;
		private bool _isPacket;
		private string _name;
		private float _cost;
		private TimeSpan _start;
		private TimeSpan _stop;
		private bool _isNonFixed;

		public int IdGroup { get; set; }

		public string Name
		{
			get => _name;
			set
			{
				if (value == _name) return;
				_name = value;
				OnPropertyChanged();
			}
		}

		public TimeSpan Start
		{
			get => _start;
			set
			{
				if (value == _start) return;
				_start = value;
				OnPropertyChanged();
			}
		}

		public DateTime StartTime
		{
			get
			{
				var time = new DateTime(1, 1, 1, Start.Hours, Start.Minutes, 0);
				return time;
			}

			set
			{
				Start = new TimeSpan(value.Hour, value.Minute, 0);
			}
		}

		public TimeSpan Stop
		{
			get => _stop;
			set
			{
				if (value == _stop) return;
				_stop = value;
				
				OnPropertyChanged();
			}
		}

		public DateTime StopTime
		{
			get
			{
				var time = new DateTime(1, 1, 1, Stop.Hours, Stop.Minutes, 0);
				return time;
			}

			set
			{
				Stop = new TimeSpan(value.Hour, value.Minute, 0);
			}
		}

		public float Cost
		{
			get => _cost;
			set
			{
				if (value == _cost) return;
				_cost = value;
				OnPropertyChanged();
			}
		}

		public bool IsPacket
		{
			get => _isPacket;
			set
			{
				if (value == _isPacket) return;
				_isPacket = value;
				if (value == false)
					_isNonFixed = false;
				OnPropertyChanged();
			}
		}

		public bool IsNonFixed
		{
			get => _isNonFixed;
			set
			{
				if (value == _isNonFixed) return;
				_isNonFixed = value;
				if (_isNonFixed == true)
					_stop = new TimeSpan(0, 0, 0);
				OnPropertyChanged();
			}
		}

		public string Condition { get; set; }

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

		public ComputerGroupView ComputerGroup
		{
			get => _computerGroup;
			set
			{
				if (Equals(value, _computerGroup)) return;
				_computerGroup = value;
				IdGroup = value.Id;
				OnPropertyChanged();
			}
		}

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