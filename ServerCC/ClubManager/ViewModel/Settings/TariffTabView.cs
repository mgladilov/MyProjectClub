using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataLayer;
using DataLayer.Model;

namespace ClubManager.ViewModel.Settings
{
	public class TariffTabView : BaseView
	{
		private readonly DataBaseContext _context;
		private ComputerGroup _selectedGroup;
		private ObservableCollection<TariffInterval> _tariffIntervals;
		private TariffInterval _selectedInterval;

		public ObservableCollection<ComputerGroup> ComputerGroups { get; set; }

		public ObservableCollection<TariffInterval> TariffIntervals
		{
			get => _tariffIntervals;
			set
			{
				if (Equals(value, _tariffIntervals)) return;
				_tariffIntervals = value;
				OnPropertyChanged();
			}
		}

		public List<TariffInterval> TariffIntervalTemp { get; set; }

		public ComputerGroup SelectedGroup
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

		public TariffInterval SelectedInterval
		{
			get => _selectedInterval;
			set
			{
				if (Equals(value, _selectedInterval)) return;
				_selectedInterval = value;
				OnPropertyChanged();
			}
		}

		private void OnSelected(ComputerGroup value)
		{
			if(value == null)
				return;
			TariffIntervals = new ObservableCollection<TariffInterval>(TariffIntervalTemp.Where(i => i.IdGroup == value.Id));

		}

		public TariffTabView(DataBaseContext context)
		{
			_context = context;
			Title = "Tariff";
		}

		public void Load()
		{
			var computerGroups = _context.ComputerGroups.Where(i => !i.IsDeleted).ToList();
			var tariffInterval = _context.TariffIntervals.Where(i => !i.IsDeleted).ToList();

			ComputerGroups = new ObservableCollection<ComputerGroup>(computerGroups);
			//TariffIntervals = new ObservableCollection<TariffInterval>(tariffInterval);
			TariffIntervalTemp = new List<TariffInterval>(tariffInterval);
		}
	}
}