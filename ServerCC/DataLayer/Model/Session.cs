﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
	[Table("Sessions", Schema = "dbo")]
	public class Session : BaseModel
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
	}
}