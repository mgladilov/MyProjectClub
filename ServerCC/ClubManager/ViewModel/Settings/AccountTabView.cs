using System.Collections.ObjectModel;
using System.Linq;
using ClubManager.Helpers;
using DataLayer;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.ViewModel.Settings
{
	public class AccountTabView : BaseView
	{
		private readonly DataBaseContext _context;
		private ObservableCollection<Account> _accounts;
		private Account _selectedAccount;
		public ObservableCollection<Account> Accounts
		{
			get => _accounts;
			set
			{
				if (Equals(value, _accounts)) return;
				_accounts = value;
				OnPropertyChanged();
			}
		}
		public Account SelectedAccount
		{
			get => _selectedAccount;
			set
			{
				if (Equals(value, _selectedAccount)) return;
				_selectedAccount = value;
				OnPropertyChanged();
			}
		}

		public AccountTabView(DataBaseContext context)
		{
			_context = context;
		}

		
		public void Load()
		{
			var accounts = _context.Accounts.Where(i => !i.IsDeleted).OrderBy(i => i.Id).ToList();
			
			Accounts = new ObservableCollection<Account>(accounts);
		}


		private RelayCommand _update;
		public RelayCommand Update
		{
			get
			{
				return _update ??= new RelayCommand(o =>
				{
					if (SelectedAccount == null)
						return;

					if (SelectedAccount.Id <= 0)
					{
						var entity = _context.Accounts.Attach(SelectedAccount);
						entity.State = EntityState.Added;
					}
					_context.SaveChanges();

					Load();
				});
			}
		}

		private RelayCommand _delete;
		public RelayCommand Delete
		{
			get
			{
				return _delete ??= new RelayCommand(o =>
				{
					if (SelectedAccount == null)
						return;
					SelectedAccount.IsDeleted = true;

					Accounts.Remove(SelectedAccount);

					_context.SaveChanges();
				});
			}
		}

	}
}