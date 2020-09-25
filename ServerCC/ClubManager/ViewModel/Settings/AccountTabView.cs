using System;
using System.Collections.Generic;
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
		private List<Account> AccountTemp;
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
			Title = "Account";
		}

		
		public void Load()
		{
			var accounts = _context.Accounts.Where(i => !i.IsDeleted).OrderBy(i => i.Id).ToList();
			
			AccountTemp = new List<Account>(accounts);
			Accounts = new ObservableCollection<Account>(accounts);
		}

		private string _filterText;
		public string FilterText
		{
			get => _filterText;
			set
			{
				_filterText = value;
				Filtering();
			}
		}

		private void Filtering()
		{
			Accounts = new ObservableCollection<Account>(AccountTemp.Where(i => i.Id.ToString()
				                                                                    .Contains(_filterText) || i.Name
				                                                                    .Contains(_filterText, StringComparison.InvariantCultureIgnoreCase)));
		}


		#region Update

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

		#endregion

		#region Delete

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

		#endregion
		
	}
}