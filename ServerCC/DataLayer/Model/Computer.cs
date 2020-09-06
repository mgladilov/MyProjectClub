using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
	[Table("Computers", Schema = "dbo")]
	public class Computer : BaseModel
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