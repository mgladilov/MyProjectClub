namespace ClubManager.ViewModel.Settings
{
	public class SettingView : BaseView
	{
		private ComputerTabView _computerTabView;
		private AccountTabView _accountTabView;

		public SettingView(ComputerTabView computerTabView, AccountTabView accountTabView) :this()
		{
			_computerTabView = computerTabView;
			_accountTabView = accountTabView;
		}
		
		public SettingView()
		{
			Title = "Settings";
		}
		
		public ComputerTabView ComputerTabView
		{
			get => _computerTabView;
			set => _computerTabView = value;
		}

		public AccountTabView AccountTabView
		{
			get => _accountTabView;
			set => _accountTabView = value;
		}
	}
}
