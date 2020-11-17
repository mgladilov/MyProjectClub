using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("Sessions", Schema = "dbo")]
	public class Session : BaseEntity
	{
		[Column("IdComp")]
		public int IdComp { get; set; }

		[Column("IdTarif")]
		public int IdTarif { get; set; }

		[Column("IdClients")]
		public int IdClients { get; set; }

		[Column("Start")]
		public DateTime Start { get; set; }

		[Column("Stop")]
		public DateTime Stop { get; set; }

		[Column("IsPacket")]
		public bool IsPacket { get; set; }

		[Column("IdOperator")]
		public int IdOperator { get; set; }

		[Column("AdditionalInformationJSON")]
		public string AdditionalInformationJSON { get; set; }
	}
}