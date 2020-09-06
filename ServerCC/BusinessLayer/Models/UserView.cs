
namespace BusinessLayer.Models
{
	public class UserView : BaseModel
	{
		public string Name { get; set; }

		public string Password { get; set; }

		public string Phone { get; set; }

		public string Address { get; set; }

		public string Email { get; set; }

		public int IdUsersGroup { get; set; }

		public string Remark { get; set; }
		
	}
}