using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("Computers", Schema = "dbo")]
	public class Computer : BaseEntity
	{
		[Column("Number")]
		public int Number { get; set; }

		[Column("IpAddress")]
		public string IpAddress { get; set; }

		[Column("IdGroup")]
		public int IdGroup { get; set; }

		[ForeignKey(nameof(IdGroup))]
		public ComputerGroup  ComputerGroup { get; set; }
	}
}