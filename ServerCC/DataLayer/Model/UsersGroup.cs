using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("UsersGroups", Schema = "dbo")]
	public class UsersGroup : BaseEntity
	{
		[Column("Name")]
		public string Name { get; set; }

		public ICollection<User> Users { get; set; }
	}
}