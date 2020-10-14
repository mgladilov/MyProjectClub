using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Models;
using BusinessLayer.Repositories;
using DataLayer.Extensions;
using DataLayer.Model;

namespace ClubManager.ViewModel.Settings
{
	public class UserTabView : BaseView
	{
		private readonly IMapper _mapper;
		private readonly IRepository<User> _userRepo;
		private readonly IRepository<UsersGroup> _userGroupRepo;
		private UserView _selectedUser;
		private UsersGroupView _selecredUsersGroup;

		public ObservableCollection<UserView> Users { get; set; }
		public ObservableCollection<UsersGroupView> UserGroups { get; set; }

		public UserView SelectedUser
		{
			get => _selectedUser;
			set
			{
				if (Equals(value, _selectedUser)) return;
				_selectedUser = value;
				OnPropertyChanged();
			}
		}

		public UsersGroupView SelectedUsersGroup
		{
			get => _selecredUsersGroup;
			set
			{
				if (Equals(value, _selecredUsersGroup)) return;
				_selecredUsersGroup = value;
				OnPropertyChanged();
			}
		}


		public UserTabView()
		{
			
		}

		public UserTabView(IMapper mapper,
			IRepository<User> userRepo,
			IRepository<UsersGroup> userGroupRepo)
		{
			_mapper = mapper;
			_userRepo = userRepo;
			_userGroupRepo = userGroupRepo;
		}

		public void Load()
		{
			var users = _userRepo.GetAll().OnlyActive().ToList();
			var userView = _mapper.MapToBlView<User, UserView>(users);

			var userGroups = _userGroupRepo.GetAll().OnlyActive().ToList();
			var userGroupView = _mapper.MapToBlView<UsersGroup, UsersGroupView>(userGroups);

			foreach (var view in userView)
				view.UsersGroup = userGroupView.FirstOrDefault(i => i.Id == view.IdUsersGroup);

			Users = new ObservableCollection<UserView>(userView);
			UserGroups = new ObservableCollection<UsersGroupView>(userGroupView);
		}
	}
}