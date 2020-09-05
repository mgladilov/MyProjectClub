using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClubManager
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public IServiceProvider ServiceProvider { get; set; }
		public IConfiguration Configuration { get; set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetings.json", false,true);
			Configuration = builder.Build();
			var services = new ServiceCollection();
			ConfigureServices(services);

			var all = Assembly
				.GetEntryAssembly()
				.GetReferencedAssemblies()
				.Select(Assembly.Load)
				.SelectMany(x => x.DefinedTypes)
				.Where(type => typeof(Profile).IsAssignableFrom(type));
			services.AddAutoMapper(all.ToArray());

			services.AddDbContext<DataBaseContext>(b =>
			{
				b.UseSqlServer(Configuration.GetConnectionString("Sql"), optionsBuilder =>
					{
						optionsBuilder.CommandTimeout(180);
					});
				b.EnableDetailedErrors();
			});

			ServiceProvider = services.BuildServiceProvider();
			var mainForm = ServiceProvider.GetRequiredService<MainWindow>();
			mainForm.Show();
		}

		private void ConfigureServices(ServiceCollection services)
		{
			services.AddTransient<MainWindow>();
		}
	}
}
