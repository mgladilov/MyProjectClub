using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ClubManager.Converters
{
	public class BoolToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter,
			CultureInfo culture)
		{
			var strings = ((string)parameter)?.Split(',');
			return (bool) value ? strings?.FirstOrDefault() : strings?.LastOrDefault();
		}

		public object ConvertBack(object value, Type targetType, object parameter,
			CultureInfo culture)
		{
			var strings = ((string)parameter)?.Split(',');
			return strings?.FirstOrDefault()?.Equals(value);
			
		}
	}
}