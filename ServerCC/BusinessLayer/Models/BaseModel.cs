namespace BusinessLayer.Models
{
	public interface IBaseModel
	{
		int Id { get; set; }

		bool IsDeleted { get; set; }
	}

	public class BaseModel : IBaseModel
	{
		public int Id { get; set; }

		public bool IsDeleted { get; set; }
	}
}