using System;

namespace b
{
	class MainClass
	{
		// количество вариантов, оканчивающихся на красную
		public static int count_red(int l)
		{
			if (l == 1)
				return 1;
			return count_blue(l-1) + count_green(l-1);
		}

		// количество вариантов, оканчивающихся на синюю
		public static int count_blue(int l)
		{
			if (l == 1)
				return 1;
			return count_blue(l-1) + count_green(l-1);
		}

		// количество вариантов, оканчивающихся на зелёную
		public static int count_green(int l)
		{
			if (l == 1)
				return 1;
			if ((l & (l - 1)) == 0)
				return count_red(l-1) + count_blue(l-1) + count_green(l-1);
			
			return 0;
		}

		public static int count(int l)
		{
			return count_red(l) + count_blue(l) + count_green(l);
		}

		public static void Main (string[] args)
		{
			for (int i = 1; i<=15; i++)
				Console.WriteLine ("Количество вариантов длины {0,2} равно {1}", i, count(i));
		}
	}
}
