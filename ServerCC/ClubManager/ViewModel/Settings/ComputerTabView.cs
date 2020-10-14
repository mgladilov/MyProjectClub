using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Models;
using BusinessLayer.Repositories;
using ClubManager.Helpers;
using DataLayer;
using DataLayer.Extensions;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.ViewModel.Settings
{
	public class ComputerTabView
	{
		private readonly IMapper _mapper;
		private readonly IRepository<Computer> _computerRepo;
		private readonly IRepository<ComputerGroup> _computerGroupRepo;

		public ObservableCollection<ComputerView> Computers { get; set; }
		public ObservableCollection<ComputerGroupView> ComputerGroups { get; set; }
		public ComputerView SelectedComputer { get; set; }
		public ComputerGroupView SelectedGroup { get; set; }


		public ComputerTabView()
		{
			
		}

		public ComputerTabView(IMapper mapper,
			IRepository<Computer> computerRepo,
			IRepository<ComputerGroup> computerGroupRepo)
		{
			_mapper = mapper;
			_computerRepo = computerRepo;
			_computerGroupRepo = computerGroupRepo;
		}

		public void Load()
		{
			var computers = _computerRepo.GetAll().OnlyActive().OrderBy(i => i.Number).ToList();
			var computerViews = _mapper.MapToBlView<Computer, ComputerView>(computers);

			var computerGroups = _computerGroupRepo.GetAll().OnlyActive().ToList();
			var computerGroupView = _mapper.MapToBlView<ComputerGroup, ComputerGroupView>(computerGroups);


			foreach (var view in computerViews)
			{
				view.ComputerGroup = computerGroupView.FirstOrDefault(i => i.Id == view.IdGroup);
			}

			Computers = new ObservableCollection<ComputerView>(computerViews);
			ComputerGroups = new ObservableCollection<ComputerGroupView>(computerGroupView);
		}

		#region Button update

		private RelayCommand _update;
		public RelayCommand Update
		{
			get
			{
				return _update ??= new RelayCommand(o =>
				{
					var updated = Computers.Where(i => i.IsModified);
					foreach (var view in updated)
					{
						var computer = _mapper.MapToEntity<ComputerView, Computer>(view);
						var entity = _computerRepo.Save(computer);
						view.Id = entity.Id;
					}
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
					var updated = ComputerGroups.Where(i => i.IsModified);
					foreach (var view in updated)
					{
						var computerGroup = _mapper.MapToEntity<ComputerGroupView, ComputerGroup>(view);
						var entity = _computerGroupRepo.Save(computerGroup);
						view.Id = entity.Id;
					}
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
					_computerRepo.Delete(SelectedComputer.Id);
					Computers.Remove(SelectedComputer);
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
					
					_computerGroupRepo.Delete(SelectedGroup.Id);
					ComputerGroups.Remove(SelectedGroup);
				});
			}
		}

		#endregion
	}
}
