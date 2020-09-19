using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
	public interface IBaseEntity
	{
		int Id { get; set; }

		bool IsDeleted { get; set; }
	}
	
	public class BaseEntity : IBaseEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; set; }

		[Column("IsDeleted")]
		public bool IsDeleted { get; set; }
	}
}