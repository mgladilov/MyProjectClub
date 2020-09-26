namespace ClubManager.ViewModel.Settings
{
	public class SettingView : BaseView
	{
		private ComputerTabView _computerTabView;
		private AccountTabView _accountTabView;
		private TariffTabView _tariffTabView;

		public SettingView(ComputerTabView computerTabView, AccountTabView accountTabView, TariffTabView tariffTabView) :this()
		{
			_computerTabView = computerTabView;
			_accountTabView = accountTabView;
			_tariffTabView = tariffTabView;
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
	}
}
