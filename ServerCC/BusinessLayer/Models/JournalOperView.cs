using System;

namespace BusinessLayer.Models
{
	public class JournalOperView : BaseModel
	{
		public float Summa { get; set; }

		public DateTime Moment { get; set; }

		public int IdUsers { get; set; }

		public string Remark { get; set; }
	}
}