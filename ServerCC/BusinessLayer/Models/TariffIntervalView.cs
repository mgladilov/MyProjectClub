using System;

namespace BusinessLayer.Models
{
	public class TariffIntervalView : BaseModel
	{
		public int IdGroup { get; set; }

		public string Name { get; set; }

		public DateTime Start { get; set; }

		public DateTime Stop { get; set; }

		public float Cost { get; set; }

		public bool IsPacket { get; set; }

		public string Condition { get; set; }

		public string DaysOfWeek { get; set; }
	}
}