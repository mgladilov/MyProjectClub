namespace BusinessLayer.Models
{
	public class ComputerView : BaseModel
	{
		private int _number;
		private string _ipAddress;
		private ComputerGroupView _computerGroup;

		public int Number
		{
			get => _number;
			set
			{
				if (value == _number) return;
				_number = value;
				OnPropertyChanged();
			}
		}

		public string IpAddress
		{
			get => _ipAddress;
			set
			{
				if (value == _ipAddress) return;
				_ipAddress = value;
				OnPropertyChanged();
			}
		}

		public int IdGroup { get; set; }

		public ComputerGroupView ComputerGroup
		{
			get => _computerGroup;
			set
			{
				if (Equals(value, _computerGroup)) return;
				_computerGroup = value;
				OnPropertyChanged();
			}
		}
	}
}