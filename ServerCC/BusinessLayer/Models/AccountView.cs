namespace BusinessLayer.Models
{
	public class AccountView : BaseModel
	{
		private string _name;
		private string _password;
		private string _email;
		private string _phone;
		private string _address;
		private bool _isBlocked;
		private bool _isPrivileged;
		private int _privilegedDiscount;
		private double _balance;
		private double _summary;
		private string _remark;

		public string Name
		{
			get => _name;
			set
			{
				if (value == _name) return;
				_name = value;
				OnPropertyChanged();
			}
		}

		public string Password
		{
			get => _password;
			set
			{
				if (value == _password) return;
				_password = value;
				OnPropertyChanged();
			}
		}

		public string Email
		{
			get => _email;
			set
			{
				if (value == _email) return;
				_email = value;
				OnPropertyChanged();
			}
		}

		public string Phone
		{
			get => _phone;
			set
			{
				if (value == _phone) return;
				_phone = value;
				OnPropertyChanged();
			}
		}

		public string Address
		{
			get => _address;
			set
			{
				if (value == _address) return;
				_address = value;
				OnPropertyChanged();
			}
		}

		public bool IsBlocked
		{
			get => _isBlocked;
			set
			{
				if (value == _isBlocked) return;
				_isBlocked = value;
				OnPropertyChanged();
			}
		}

		public bool IsPrivileged
		{
			get => _isPrivileged;
			set
			{
				if (value == _isPrivileged) return;
				_isPrivileged = value;
				OnPropertyChanged();
			}
		}

		public int PrivilegedDiscount
		{
			get => _privilegedDiscount;
			set
			{
				if (value == _privilegedDiscount) return;
				_privilegedDiscount = value;
				OnPropertyChanged();
			}
		}

		public int ZeroBalance { get; set; }

		public double Balance
		{
			get => _balance;
			set
			{
				if (value == _balance) return;
				_balance = value;
				OnPropertyChanged();
			}
		}

		public double Summary
		{
			get => _summary;
			set
			{
				if (value == _summary) return;
				_summary = value;
				OnPropertyChanged();
			}
		}

		public string Remark
		{
			get => _remark;
			set
			{
				if (value == _remark) return;
				_remark = value;
				OnPropertyChanged();
			}
		}
	}
}