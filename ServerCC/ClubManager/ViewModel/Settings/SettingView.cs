namespace ClubManager.ViewModel.Settings
{
	public class SettingView : BaseView
	{
		private ComputerTabView _computerTabView;
		private AccountTabView _accountTabView;
		private TariffTabView _tariffTabView;
		private UserTabView _userTabView;

		public SettingView(ComputerTabView computerTabView, AccountTabView accountTabView, TariffTabView tariffTabView, UserTabView userTabView) :this()
		{
			_computerTabView = computerTabView;
			_accountTabView = accountTabView;
			_tariffTabView = tariffTabView;
			_userTabView = userTabView;
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

		public TariffTabView TariffTabView
		{
			get => _tariffTabView;
			set => _tariffTabView = value;
		}

		public UserTabView UserTabView
		{
			get => _userTabView;
			set => _userTabView = value;
		}
	}
}
