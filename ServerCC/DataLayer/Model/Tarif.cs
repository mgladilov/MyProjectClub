using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
	[Table("Tarifs", Schema = "dbo")]
	public class Tarif : BaseModel
	{
		[Column("Name")]
		public string Name { get; set; }

		[Column("IdComputerGroup")]
		public int IdComputerGroups { get; set; }
	}
}