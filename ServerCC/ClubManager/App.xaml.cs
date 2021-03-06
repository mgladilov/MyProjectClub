﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using AutoMapper;
using BusinessLayer.Repositories;
using ClubManager.ViewModel;
using ClubManager.ViewModel.Settings;
using DataLayer;
using DataLayer.Model;
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
			ConfigureRepository(services);


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

		private void ConfigureRepository(ServiceCollection services)
		{
			services.AddScoped<IRepository<Computer>, Repository<Computer>>();
			services.AddScoped<IRepository<ComputerGroup>, Repository<ComputerGroup>>();
			services.AddScoped<IRepository<Account>, Repository<Account>>();
			services.AddScoped<IRepository<TariffInterval>, Repository<TariffInterval>>();
			services.AddScoped<IRepository<User>, Repository<User>>();
			services.AddScoped<IRepository<UsersGroup>, Repository<UsersGroup>>();
		}

		private void ConfigureServices(ServiceCollection services)
		{
			services.AddSingleton<MainWindowView>();
			services.AddTransient<SettingsWindow>();
			services.AddTransient<MainWindow>();
			services.AddSingleton<SettingView>();
			services.AddSingleton<ComputerTabView>();
			services.AddSingleton<AccountTabView>();
			services.AddSingleton<TariffTabView>();
			services.AddSingleton<UserTabView>();
		}
	}
}
