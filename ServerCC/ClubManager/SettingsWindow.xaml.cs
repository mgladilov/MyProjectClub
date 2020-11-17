using ClubManager.ViewModel;
using ClubManager.ViewModel.Settings;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ClubManager
{
	/// <summary>
	/// Interaction logic for SettingsWindow.xaml
	/// </summary>
	public partial class SettingsWindow : MetroWindow
	{
		public SettingsWindow(SettingView view)
		{
			InitializeComponent();
			view.AccountTabView.Cordinator = DialogCoordinator.Instance;
			view.ComputerTabView.Load();
			view.AccountTabView.Load();
			view.TariffTabView.Load();
			view.UserTabView.Load();
			this.DataContext = view;
		}
	}
}
