using System;
using System.Globalization;

namespace angle
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//DateTime time = DateTime.Now;
			//Console.WriteLine("В данный момент {0:HH} часов {0:mm} минут.");

			Console.WriteLine ("Введите время в формате HH:mm:");
			DateTime time = DateTime.ParseExact (Console.ReadLine(), "HH:mm", CultureInfo.InvariantCulture);

			int val_h = time.Hour % 12,
			    val_m = time.Minute;
			float angle_h = 30 * (val_h + val_m/60),
			      angle_m = 6*val_m;
			float angle = Math.Abs (angle_h - angle_m);
			float angle_min = Math.Min (angle, Math.Abs (angle - 360));

			Console.WriteLine ("Стрелки часов образуют {0} градусов", angle_min);
		}
	}
}
