using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("Tarifs", Schema = "dbo")]
	public class Tarif : BaseEntity
	{
		[Column("Name")]
		public string Name { get; set; }

		[Column("IdComputerGroup")]
		public int IdComputerGroups { get; set; }
	}
}