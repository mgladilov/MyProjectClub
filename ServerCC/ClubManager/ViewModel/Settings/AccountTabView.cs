using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Models;
using BusinessLayer.Repositories;
using ClubManager.Helpers;
using DataLayer.Extensions;
using DataLayer.Model;
using MahApps.Metro.Controls.Dialogs;

namespace ClubManager.ViewModel.Settings
{
	public class AccountTabView : BaseView

	{
		private readonly IMapper _mapper;
		private readonly IRepository<Account> _accountRepo;
		private readonly IServiceProvider _provider;
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
			IRepository<Account> accountRepo,
			IServiceProvider provider)
		{
			_mapper = mapper;
			_accountRepo = accountRepo;
			_provider = provider;
		}


		public void Load()
		{
			var accounts = _accountRepo.GetAll().OnlyActive().OrderBy(i => i.Id).ToList();
			var accountViews = _mapper.MapToBlView<Account, AccountView>(accounts);

			_accountTemp = new List<AccountView>(accountViews);
			Accounts = new ObservableCollection<AccountView>(accountViews);
		}

		#region Filter Account

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

		#endregion

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

		private RelayCommand _addBalance;
		public RelayCommand AddBalace
		{
			get
			{
				return _addBalance ??= new RelayCommand(async o =>
				{
					if(SelectedAccount == null)
						return;
					var res = await Cordinator.ShowInputAsync(this, "Добавить на счет", $"{SelectedAccount.Name} = {SelectedAccount.Balance}", new MetroDialogSettings
					{
						DialogResultOnCancel = MessageDialogResult.Canceled
					});
					if(string.IsNullOrEmpty(res))
						return;
					if (int.TryParse(res, out var balance))
					{
						SelectedAccount.Balance += balance;
						SelectedAccount.Summary += balance;
						var account = _mapper.MapToEntity<AccountView, Account>(SelectedAccount);
						_accountRepo.Save(account);
					}
					else
					{
						await Cordinator.ShowMessageAsync(this, "Ошибка", "Введите цифры");
					}
				});
			}
		}

		private RelayCommand _withdrawBalance;
		public RelayCommand WithdrawBalance
		{
			get
			{
				return _withdrawBalance ??= new RelayCommand(async o =>
				{
					if (SelectedAccount == null)
						return;
					var res = await Cordinator.ShowInputAsync(this, "Снять со счета", $"{SelectedAccount.Name} = {SelectedAccount.Balance}", new MetroDialogSettings
					{
						DialogResultOnCancel = MessageDialogResult.Canceled
					});
					if (string.IsNullOrEmpty(res))
						return;
					if (int.TryParse(res, out var balance))
					{
						SelectedAccount.Balance -= balance;
						var account = _mapper.MapToEntity<AccountView, Account>(SelectedAccount);
						_accountRepo.Save(account);
					}
					else
					{
						await Cordinator.ShowMessageAsync(this, "Ошибка", "Введите цифры");
					}
				});
			}
		}

		public IDialogCoordinator Cordinator { get; set; }
	}
}