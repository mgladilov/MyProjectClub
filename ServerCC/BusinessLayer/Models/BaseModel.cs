using System.ComponentModel;
using System.Runtime.CompilerServices;

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

		public bool IsModified { get; set; }


		#region INotif

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (PropertyChanged != null)
			{
				IsModified = true;
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion

	}
}