using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Models;
using DataLayer;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ClubManager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly DataBaseContext _context;
		private readonly IMapper _mapper;

		public MainWindow()
		{
			InitializeComponent();
		}

		public MainWindow(DataBaseContext context, IMapper mapper) : this()
		{
			_context = context;
			_mapper = mapper;
			Load();
		}

		private async Task Load()
		{
			var computers = await _context.Computers.Where(i => !i.IsDeleted).AsNoTracking().ToListAsync();
			var computerViews = _mapper.MapToBlView<Computer, ComputerView>(computers);
			compGrid.ItemsSource = computerViews;
		}

		private void updateButton_Click(object sender, RoutedEventArgs e)
		{
			var computers = _mapper.MapToEntity<ComputerView, Computer>(compGrid.SelectedItems.OfType<ComputerView>());
			foreach (var computer in computers)
			{
				_context.Attach(computer);
				if (computer.Id > 0)
					_context.Entry(computer).State = EntityState.Modified;
				else
					_context.Entry(computer).State = EntityState.Added;
			}
			_context.SaveChanges();
		}

		private void deleteButton_Click(object sender, RoutedEventArgs e)
		{
			if (!compGrid.SelectedItems.Any())
				return;

			var computers = _mapper.MapToEntity<ComputerView, Computer>(compGrid.SelectedItems.OfType<ComputerView>());
			_context.Computers.RemoveRange(computers);

			_context.SaveChanges();
		}
	}
}
