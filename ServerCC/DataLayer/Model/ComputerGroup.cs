using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("ComputerGroups", Schema = "dbo")]
	public class ComputerGroup : BaseEntity
	{ 
		[Column("Name")]
		public string Name { get; set; }


		public ICollection<Computer> Computers { get; set; }
	}
}