using System;

namespace s
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int n;
			Console.WriteLine ("Введите число:");
			n = int.Parse (Console.ReadLine ());

			int res = 0;
			for (int i = 2; i <= n; i = i*4) {
				if ((i & n) != 0) {
					res++;
				}
			}

			Console.WriteLine ("В записи числа {0} (\"{1}\") ровно {2} единиц, стоящих на чётных позициях.", n, Convert.ToString(n, 2), res);
		}
	}
}
