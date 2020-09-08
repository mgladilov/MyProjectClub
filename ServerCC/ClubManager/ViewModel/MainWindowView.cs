using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Models;
using ClubManager.Helpers;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.ViewModel
{
	public class MainWindowView
	{
		private readonly DataBaseContext _context;
		private readonly IMapper _mapper;

		public ObservableCollection<ComputerView> Computers { get; set; }
		public ObservableCollection<ComputerGroupView> ComputersGroups { get; set; }
		public ComputerView SelectedComputer { get; set; }

		public MainWindowView()
		{

		}

		public MainWindowView(DataBaseContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
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
					if (computer.Id > 0)
						_context.Entry(computer).State = EntityState.Modified;
					else
						_context.Entry(computer).State = EntityState.Added;

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

	}
}
