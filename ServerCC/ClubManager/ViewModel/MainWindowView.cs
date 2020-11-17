using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Models;
using BusinessLayer.Repositories;
using ClubManager.Helpers;
using DataLayer;
using DataLayer.Extensions;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClubManager.ViewModel
{
	public class MainWindowView : BaseView
	{
		private readonly IMapper _mapper;
		private readonly IServiceProvider _provider;
		private readonly IRepository<Computer> _computerRepo;
		private readonly IRepository<ComputerGroup> _computerGroupRepo;

		public ObservableCollection<ComputerView> Computers { get; set; }
		public ObservableCollection<ComputerGroupView> ComputersGroups { get; set; }
		public ComputerView SelectedComputer { get; set; }

		public MainWindowView()
		{
			
		}

		private DispatcherTimer _timer;

		public DateTime CurrentTime { get { return DateTime.Now; } }

		public void TimeTest()
		{
			_timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
			_timer.Start();
			_timer.Tick += (o, e) => OnPropertyChanged("CurrentTime");
		}


		public MainWindowView(IMapper mapper,
			IServiceProvider provider,
			IRepository<Computer> computerRepo,
			IRepository<ComputerGroup> computerGroupRepo)
		{
			_mapper = mapper;
			_provider = provider;
			_computerRepo = computerRepo;
			_computerGroupRepo = computerGroupRepo;
		}
				

		public void Load()
		{
			var computers = _computerRepo.GetAll().OnlyActive().AsNoTracking().ToList();
			var computerViews = _mapper.MapToBlView<Computer, ComputerView>(computers);

			var computersGroups = _computerGroupRepo.GetAll().OnlyActive().AsNoTracking().ToList();
			var computerGroupView= _mapper.MapToBlView<ComputerGroup, ComputerGroupView>(computersGroups);

			foreach (var view in computerViews)
				view.ComputerGroup = computerGroupView.FirstOrDefault(i => i.Id == view.IdGroup);

			Computers = new ObservableCollection<ComputerView>(computerViews);
			ComputersGroups = new ObservableCollection<ComputerGroupView>(computerGroupView);
			TimeTest();
		}


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
					}
				);
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

					_computerRepo.Delete(SelectedComputer.Id);
					Computers.Remove(SelectedComputer);
				});
			}
		}

		private RelayCommand _setting;
		public RelayCommand Setting
		{
			get
			{
				return _setting ??= new RelayCommand(o =>
				{
					var window = _provider.GetService<SettingsWindow>();
					window.Show();
				});
			}
		}
	}
}
