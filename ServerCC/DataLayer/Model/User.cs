using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	[Table("Users", Schema = "dbo")]
	public class User : BaseEntity
	{
		[Column("Name")]
		public string Name { get; set; }

		[Column("Password")]
		public string Password { get; set; }

		[Column("Phone")]
		public string Phone { get; set; }

		[Column("Address")]
		public string Address { get; set; }

		[Column("Email")]
		public string Email { get; set; }

		[Column("IdUsersGroup")]
		public int IdUsersGroup { get; set; }

		[Column("Remark")]
		public string Remark { get; set; }
		
	}
}