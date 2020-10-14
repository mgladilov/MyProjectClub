using ClubManager.ViewModel;
using ClubManager.ViewModel.Settings;
using MahApps.Metro.Controls;

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
			view.ComputerTabView.Load();
			view.AccountTabView.Load();
			view.TariffTabView.Load();
			view.UserTabView.Load();
			this.DataContext = view;
		}
	}
}
