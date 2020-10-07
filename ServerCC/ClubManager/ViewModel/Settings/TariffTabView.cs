using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Models;
using BusinessLayer.Repositories;
using ClubManager.Helpers;
using DataLayer;
using DataLayer.Extensions;
using DataLayer.Model;

namespace ClubManager.ViewModel.Settings
{
	public class TariffTabView : BaseView
	{
		private readonly IMapper _mapper;
		private readonly IRepository<TariffInterval> _tariffIntervalRepo;
		private readonly IRepository<ComputerGroup> _computerGroupRepo;

		private ComputerGroupView _selectedGroup;
		private ObservableCollection<TariffIntervalView> _tariffIntervals;
		private TariffIntervalView _selectedInterval;
		public ObservableCollection<ComputerGroupView> ComputerGroups { get; set; }

		public ObservableCollection<TariffIntervalView> TariffIntervals
		{
			get => _tariffIntervals;
			set
			{
				if (Equals(value, _tariffIntervals)) return;
				_tariffIntervals = value;
				OnPropertyChanged();
			}
		}

		public List<TariffIntervalView> TariffIntervalTemp { get; set; }

		public ComputerGroupView SelectedGroup
		{
			get => _selectedGroup;
			set
			{
				if (Equals(value, _selectedGroup)) return;
				_selectedGroup = value;
				OnPropertyChanged();
				OnSelected(value);
			}
		}

		public TariffIntervalView SelectedInterval
		{
			get => _selectedInterval;
			set
			{
				if (Equals(value, _selectedInterval)) return;
				_selectedInterval = value;
				OnPropertyChanged();
			}
		}

		private void OnSelected(ComputerGroupView value)
		{
			if(value == null)
				return;
			TariffIntervals = new ObservableCollection<TariffIntervalView>(TariffIntervalTemp.Where(i => i.IdGroup == value.Id));

		}

		public TariffTabView()
		{
			
		}

		public TariffTabView(IMapper mapper,
			IRepository<TariffInterval> tariffIntervalRepo,
			IRepository<ComputerGroup> computerGroupRepo)
		{
			_mapper = mapper;
			_tariffIntervalRepo = tariffIntervalRepo;
			_computerGroupRepo = computerGroupRepo;
		}

		public void Load()
		{
			var computerGroups = _computerGroupRepo.GetAll().OnlyActive().ToList();
			var computerGroupView = _mapper.MapToBlView<ComputerGroup, ComputerGroupView>(computerGroups);

			var tariffInterval = _tariffIntervalRepo.GetAll().OnlyActive().ToList();
			var tariffIntervalView = _mapper.MapToBlView<TariffInterval, TariffIntervalView>(tariffInterval);

			ComputerGroups = new ObservableCollection<ComputerGroupView>(computerGroupView);
			//TariffIntervals = new ObservableCollection<TariffInterval>(tariffInterval);
			TariffIntervalTemp = new List<TariffIntervalView>(tariffIntervalView);
		}

		#region Update

		private RelayCommand _update;

		public RelayCommand Update
		{
			get
			{
				return _update ??= new RelayCommand(o =>
				{
					var updated = TariffIntervals.Where(i => i.IsModified);
					foreach (var view in updated)
					{
						var interval = _mapper.MapToEntity<TariffIntervalView, TariffInterval>(view);
						interval.IdGroup = SelectedGroup.Id;
						var entity = _tariffIntervalRepo.Save(interval);
						view.Id = entity.Id;
					}
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
					if (SelectedInterval == null)
						return;
					_tariffIntervalRepo.Delete(SelectedInterval.Id);
					TariffIntervals.Remove(SelectedInterval);
				});
			}
		}

		#endregion
	}
}