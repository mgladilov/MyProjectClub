using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Models;
using BusinessLayer.Repositories;
using ClubManager.Helpers;
using DataLayer.Extensions;
using DataLayer.Model;

namespace ClubManager.ViewModel.Settings
{
	public class AccountTabView : BaseView

	{
		private readonly IMapper _mapper;
		private readonly IRepository<Account> _accountRepo;
		private List<AccountView> _accountTemp;
		private ObservableCollection<AccountView> _accounts;
		private AccountView _selectedAccount;

		public ObservableCollection<AccountView> Accounts
		{
			get => _accounts;
			set
			{
				if (Equals(value, _accounts)) return;
				_accounts = value;
				OnPropertyChanged();

			}
		}

		public AccountView SelectedAccount
		{
			get => _selectedAccount;
			set
			{
				if (Equals(value, _selectedAccount)) return;
				_selectedAccount = value;
				OnPropertyChanged();
			}
		}

		public AccountTabView()
		{

		}

		public AccountTabView(IMapper mapper,
			IRepository<Account> accountRepo)
		{
			_mapper = mapper;
			_accountRepo = accountRepo;
		}


		public void Load()
		{
			var accounts = _accountRepo.GetAll().OnlyActive().OrderBy(i => i.Id).ToList();
			var accountViews = _mapper.MapToBlView<Account, AccountView>(accounts);

			_accountTemp = new List<AccountView>(accountViews);
			Accounts = new ObservableCollection<AccountView>(accountViews);
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
			Accounts = new ObservableCollection<AccountView>(_accountTemp.Where(i => i.Id.ToString()
				                                                                         .Contains(_filterText) || i
				                                                                         .Name
				                                                                         .Contains(_filterText,
					                                                                         StringComparison
						                                                                         .InvariantCultureIgnoreCase)));
		}


		#region Update

		private RelayCommand _update;

		public RelayCommand Update
		{
			get
			{
				return _update ??= new RelayCommand(o =>
				{
					var updated = Accounts.Where(i => i.IsModified);
					foreach (var view in updated)
					{
						var account = _mapper.MapToEntity<AccountView, Account>(view);
						var entity = _accountRepo.Save(account);
						view.Id = entity.Id;
					}
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
					_accountRepo.Delete(SelectedAccount.Id);
					Accounts.Remove(SelectedAccount);
				});
			}
		}

		#endregion

	}
}