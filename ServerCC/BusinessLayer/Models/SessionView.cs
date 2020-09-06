using System;

namespace BusinessLayer.Models
{
	public class SessionView : BaseModel
	{
		public int IdComp { get; set; }

		public int IdTarif { get; set; }

		public int IdClients { get; set; }

		public DateTime Start { get; set; }

		public DateTime Stop { get; set; }

		public bool IsPacket { get; set; }

		public int IdOperator { get; set; }
	}
}