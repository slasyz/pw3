using System;

namespace Application
{
	class MainClass
	{
		public static bool check(int num)
		{
			// если не нужно включать числа вроде 10*, то строгое неравенство
			// если нужно - то нестрогое
			for (int i = num; i > 2; i>>=1) {
				if ((i & 7) == 2) // последние цифры (маска "0...0111") должны быть "010"
					return true;
			}
			return false;
		}

		public static void Main (string[] args)
		{
			Console.Write("Введите число N: ");
			int n = int.Parse (Console.ReadLine ());
			int length_bin = Convert.ToString (n, 2).Length;

			int counter = 0;
			for (int i = 0; i<n; i++) {
				if (check(i)) {
					string i_bin = Convert.ToString (i, 2);
					Console.WriteLine("{0,xxx} ({1})".Replace("xxx", length_bin.ToString()), i_bin, i);
					counter++;
				}
			}
			Console.WriteLine ("\nИтак, количество чисел: {0}", counter);
		}
	}
}
