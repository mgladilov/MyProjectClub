using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
	[Table("ComputerGroups", Schema = "dbo")]
	public class ComputerGroup : BaseModel
	{ 
		[Column("Name")]
		public string Name { get; set; }


		public ICollection<Computer> Computers { get; set; }
	}
}