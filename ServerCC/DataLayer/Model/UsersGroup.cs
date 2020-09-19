using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("UsersGroup", Schema = "dbo")]
	public class UsersGroup : BaseEntity
	{
		[Column("Name")]
		public string Name { get; set; }
	}
}