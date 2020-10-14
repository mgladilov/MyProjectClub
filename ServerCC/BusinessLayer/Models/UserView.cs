
namespace BusinessLayer.Models
{
	public class UserView : BaseModel
	{
		private UsersGroupView _usersGroup;
		private string _name;
		private string _phone;
		private string _address;
		private string _email;
		private string _remark;

		public string Name
		{
			get => _name;
			set
			{
				if (Equals(value, _name)) return;
				_name = value;
				OnPropertyChanged();
			}
		}

		public string Password { get; set; }

		public string Phone
		{
			get => _phone;
			set
			{
				if (Equals(value, _phone)) return;
				_phone = value;
				OnPropertyChanged();
			}
		}

		public string Address
		{
			get => _address;
			set
			{
				if (Equals(value, _address)) return;
				_address = value;
				OnPropertyChanged();
			}
		}

		public string Email
		{
			get => _email;
			set
			{
				if (Equals(value, _email)) return;
				_email = value;
				OnPropertyChanged();
			}
		}

		public int IdUsersGroup { get; set; }

		public string Remark
		{
			get => _remark;
			set
			{
				if (Equals(value, _remark)) return;
				_remark = value;
				OnPropertyChanged();
			}
		}


		public UsersGroupView UsersGroup
		{
			get => _usersGroup;
			set
			{
				if (Equals(value, _usersGroup)) return;
				_usersGroup = value;
				IdUsersGroup = value.Id;
				OnPropertyChanged();
			}
		}
	}
}