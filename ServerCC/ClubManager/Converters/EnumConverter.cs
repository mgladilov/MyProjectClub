using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;

namespace ClubManager.Converters
{
	public class EnumConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return GetDescriptionFromEnumValue((Enum)value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return GetEnumValueFromDescription(value.ToString());
		}


		public string GetDescriptionFromEnumValue(Enum value)
		{
			var values = Enum.GetValues(value.GetType()).Cast<Enum>().Where(i => value.HasFlag(i));
			var res = new List<string>();
			foreach (var day in values)
			{
				var attribute = day.GetType()
					.GetField(day.ToString())
					.GetCustomAttributes(typeof(DescriptionAttribute), false)
					.SingleOrDefault() as DescriptionAttribute;
				res.Add(attribute == null ? day.ToString() : attribute.Description);
			}

			return !res.Any() ? "нет" : 
				res.Count == 7 ? "все" :string.Join(',', res);

		}

		public DataLayer.Model.DayOfWeek GetEnumValueFromDescription(string description)
		{
			if (description.Equals("все"))
				return (DataLayer.Model.DayOfWeek)127;

			var type = typeof(DataLayer.Model.DayOfWeek);
			var days = description.Split(',');
			FieldInfo[] fields = type.GetFields();

			DataLayer.Model.DayOfWeek res = 0;
			foreach (var day in days)
			{
				var field = fields
					.SelectMany(f => f.GetCustomAttributes(
						typeof(DescriptionAttribute), false), (
						f, a) => new { Field = f, Att = a }).SingleOrDefault(a => ((DescriptionAttribute)a.Att)
																				  .Description == day);
				if (field != null)
					res |= (DataLayer.Model.DayOfWeek)field.Field.GetRawConstantValue();

			}


			return res;
			
		}
	}
}
