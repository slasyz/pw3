using System;
using System.Globalization;	

namespace weeks
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string datetime_format = "dd.MM.yyyy";
			Console.WriteLine ("Введите первую дату в формате {0}:", datetime_format);
			DateTime date1 = DateTime.ParseExact (Console.ReadLine(), datetime_format, CultureInfo.InvariantCulture);
			Console.WriteLine ("Введите следующую дату в формате {0}:", datetime_format);
			DateTime date2 = DateTime.ParseExact (Console.ReadLine(), datetime_format, CultureInfo.InvariantCulture);

			TimeSpan ts = date2-date1;
			Console.WriteLine ("\nМежду {0:dd.MM.yyyy} и {1:dd.MM.yyyy} всего {2} полных недель.", date1, date2, Math.Abs(Convert.ToInt32(ts.TotalDays) / 7));
		}
	}
}
