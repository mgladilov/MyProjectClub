using System;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Models;
using ClubManager.Helpers;
using DataLayer;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClubManager.ViewModel
{
	public class MainWindowView
	{
		private readonly DataBaseContext _context;
		private readonly IMapper _mapper;
		private readonly IServiceProvider _provider;

		public ObservableCollection<ComputerView> Computers { get; set; }
		public ObservableCollection<ComputerGroupView> ComputersGroups { get; set; }
		public ComputerView SelectedComputer { get; set; }

		public MainWindowView()
		{

		}

		public MainWindowView(DataBaseContext context, IMapper mapper, IServiceProvider provider)
		{
			_context = context;
			_mapper = mapper;
			_provider = provider;
		}
				

		public void Load()
		{
			var computers = _context.Computers.Where(i => !i.IsDeleted).AsNoTracking().ToList();
			var computerViews = _mapper.MapToBlView<Computer, ComputerView>(computers);

			var computersGroups = _context.ComputerGroups.Where(i => !i.IsDeleted).AsNoTracking().ToList();
			var computerGroupView= _mapper.MapToBlView<ComputerGroup, ComputerGroupView>(computersGroups);

			foreach (var view in computerViews)
			{
				view.ComputerGroup = computerGroupView.FirstOrDefault(i => i.Id == view.IdGroup);
			}

			Computers = new ObservableCollection<ComputerView>(computerViews);
			ComputersGroups = new ObservableCollection<ComputerGroupView>(computerGroupView);
		}


		private RelayCommand _update;
		public RelayCommand Update
		{
			get
			{
				return  _update ??= new RelayCommand(o =>
				{
					if(SelectedComputer == null)
						return;

					var computer = _mapper.MapToEntity<ComputerView, Computer>(SelectedComputer);


					var local = _context.Computers.Local.FirstOrDefault(i => i.Id == computer.Id);
					if(local!=null)
						_context.Entry(local).State = EntityState.Detached;

					_context.Attach(computer);
					//if (computer.Id > 0)
					//	_context.Entry(computer).State = EntityState.Modified;
					//else
					//	_context.Entry(computer).State = EntityState.Added;

					_context.SaveChanges();
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

					var computer = _mapper.MapToEntity<ComputerView, Computer>(SelectedComputer);
					if (_context.Entry(computer).State == EntityState.Detached)
						_context.Attach(computer);
					computer.IsDeleted = true;

					Computers.Remove(SelectedComputer);

					_context.SaveChanges();
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
