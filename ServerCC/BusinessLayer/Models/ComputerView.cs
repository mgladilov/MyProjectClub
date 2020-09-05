namespace BusinessLayer.Models
{
	public class ComputerView : BaseModel
	{
		public int Number { get; set; }

		public string IpAddress { get; set; }

		public int IdGroup { get; set; }
	}
}