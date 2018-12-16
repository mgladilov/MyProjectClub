using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("Computers", Schema = "dbo")]
	public class Computer : BaseEntity
	{
		[Column("Number")]
		public int Number { get; set; }

		[Column("Ipaddress")]
		public string Ipaddress { get; set; }

		[Column("IdGroup")]
		public int IdGroup { get; set; }


		public ComputerGroup  ComputerGroup { get; set; }
	}
}