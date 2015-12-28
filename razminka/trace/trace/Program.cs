using System;

namespace trace
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Write ("Введите размер матрицы: ");
			int n = int.Parse (Console.ReadLine ());
			//int[,] matrix = new int[n,n];
			int trace = 0;

			for (int i = 0; i < n; i++) {
				Console.Write ("Введите {0} строку: ", i+1);
				string line = Console.ReadLine ();
				string[] line_split = line.Split (' ');
				int line_length = line_split.Length;

				if (line_length != n) {
					Console.WriteLine ("\nОШИБКА: в строке {0} символов, чем нужно", line_length < n ? "меньше" : "больше");
					return;
				}

				trace += int.Parse(line_split [i]);

				//for (int j = 0; j < n; j++)
				//	matrix [i, j] = int.Parse(line_split [j]);
			}

			Console.WriteLine ("\nСлед равен {0}", trace);
		}
	}
}
