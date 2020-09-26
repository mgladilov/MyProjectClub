using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace DataLayer.Model
{
	public interface IBaseEntity
	{
		int Id { get; set; }

		bool IsDeleted { get; set; }
	}
	
	public class BaseEntity : IBaseEntity, INotifyPropertyChanged
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; set; }

		[Column("IsDeleted")]
		public bool IsDeleted { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		[Annotations.NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}