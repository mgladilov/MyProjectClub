using System.ComponentModel;
using System.Runtime.CompilerServices;
using BusinessLayer.Annotations;

namespace BusinessLayer.Models
{
	public interface IBaseModel
	{
		int Id { get; set; }

		bool IsDeleted { get; set; }
	}

	public class BaseModel : IBaseModel, INotifyPropertyChanged
	{
		public int Id { get; set; }

		public bool IsDeleted { get; set; }


		#region INotif

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

	}
}