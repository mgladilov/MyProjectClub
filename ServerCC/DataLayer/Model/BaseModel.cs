using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
	public interface IBaseEntity
	{
		int Id { get; set; }

		bool IsDeleted { get; set; }
	}
	
	public class BaseModel : IBaseEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; set; }

		[Column("IsDeleted")]
		public bool IsDeleted { get; set; }
	}
}