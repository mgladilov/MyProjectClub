namespace BusinessLayer.Models
{
	public class ComputerGroupView : BaseModel
	{
		private string _name;

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
	}
}