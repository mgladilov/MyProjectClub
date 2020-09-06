using System;

namespace BusinessLayer.Models
{
	public class SessionAddView : BaseModel
	{
		public int IdSessionsAdd { get; set; }

		public int ActionType { get; set; }

		public DateTime Moment { get; set; }

		public float Summa { get; set; }
	}
}