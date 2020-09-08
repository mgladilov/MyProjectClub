using ClubManager.ViewModel;
using MahApps.Metro.Controls;

namespace ClubManager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{

		public MainWindow(MainWindowView view)
		{
			InitializeComponent();
			view.Load();
			this.DataContext = view;
		}
	}
}
