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
		public ObservableCollection<Computer> Computers { get; set; }
		public ObservableCollection<ComputerGroup> ComputerGroups { get; set; }
		public Computer SelectedComputer { get; set; }


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
	}
}
