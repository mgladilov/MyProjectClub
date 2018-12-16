using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Logging;
using ServerCC.Logger;

namespace ServerCC
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private ILogger logger;

		public App()
		{
			var loggerFactory = new LoggerFactory();
			loggerFactory.AddFile(@"D:\logger.txt");
			logger = loggerFactory.CreateLogger("FileLogger");
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
		}

		private void MyHandler(object sender, UnhandledExceptionEventArgs args)
		{
			Exception e = (Exception)args.ExceptionObject;
			logger.LogError(e, $" \"{DateTime.Now}\" : \"Error message:{e.Message}\"");

		}
	}
}
