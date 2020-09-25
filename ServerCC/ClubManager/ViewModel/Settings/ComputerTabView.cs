using System.Collections.ObjectModel;
using System.Linq;
using ClubManager.Helpers;
using DataLayer;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.ViewModel.Settings
{
	public class ComputerTabView : BaseView
	{
		private DataBaseContext _context;
		private ComputerGroup _selectedGroup;

		public ObservableCollection<Computer> Computers { get; set; }
		public ObservableCollection<ComputerGroup> ComputerGroups { get; set; }
		public Computer SelectedComputer { get; set; }
		public ComputerGroup SelectedGroup
		{
			get => _selectedGroup;
			set
			{
				if (Equals(value, _selectedGroup)) return;
				_selectedGroup = value;
				OnPropertyChanged();
			}
		}


		public ComputerTabView(DataBaseContext context)
		{
			_context = context;
		}

		public void Load()
		{
			var computers = _context.Computers.Where(i => !i.IsDeleted).OrderBy(i => i.Number).ToList();
			var computerGroups = _context.ComputerGroups.Where(i => !i.IsDeleted).ToList();
			
			foreach (var view in computers)
			{
				view.ComputerGroup = computerGroups.FirstOrDefault(i => i.Id == view.IdGroup);
			}

			Computers = new ObservableCollection<Computer>(computers);
			ComputerGroups = new ObservableCollection<ComputerGroup>(computerGroups);
		}

		#region Button update

		private RelayCommand _update;
		public RelayCommand Update
		{
			get
			{
				return _update ??= new RelayCommand(o =>
				{
					if (SelectedComputer == null)
						return;

					if (SelectedComputer.Id <= 0)
					{
						var entity = _context.Computers.Attach(SelectedComputer);
						entity.State = EntityState.Added;
					}
					_context.SaveChanges();

					Load();
				});
			}
		}

		private RelayCommand _updateGroup;
		public RelayCommand UpdateGroup
		{
			get
			{
				return _updateGroup ??= new RelayCommand(o =>
				{
					if (SelectedGroup == null)
						return;

					if (SelectedGroup.Id <= 0)
					{
						var entity = _context.ComputerGroups.Attach(SelectedGroup);
						entity.State = EntityState.Added;
					}
					_context.SaveChanges();

					Load();
				});
			}
		}

		#endregion

		#region Button delete

		private RelayCommand _delete;
		public RelayCommand Delete
		{
			get
			{
				return _delete ??= new RelayCommand(o =>
				{
					if (SelectedComputer == null)
						return;
					SelectedComputer.IsDeleted = true;

					Computers.Remove(SelectedComputer);

					_context.SaveChanges();
				});
			}
		}

		private RelayCommand _deleteGroup;
		public RelayCommand DeleteGroup
		{
			get
			{
				return _deleteGroup ??= new RelayCommand(o =>
				{
					if (SelectedGroup == null)
						return;
					SelectedGroup.IsDeleted = true;

					ComputerGroups.Remove(SelectedGroup);

					_context.SaveChanges();
				});
			}
		}

		#endregion
	}
}
