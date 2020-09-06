using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
	[Table("UsersGroup", Schema = "dbo")]
	public class UsersGroup : BaseModel
	{
		[Column("Name")]
		public string Name { get; set; }
	}
}