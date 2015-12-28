using System;

namespace minute
{
	class MainClass
	{
		public static int x_rec(int k)
		{
			int[] x = {1, 1, 3, 4};
			if (k <= 3)
				return x[k];

			return x_rec(k-2) + 2*x_rec(k-3) + x_rec(k-4);
		}
		public static int x_iter(int k)
		{
			int[] x = {1, 1, 3, 4};
			if (k <= 3)
				return x[k];

			for (int i = 4; i <= k; i++) {
				int x_new = x[0] + 2*x[1] + x[2];

				x[0] = x[1];
				x[1] = x[2];
				x[2] = x[3];
				x[3] = x_new;
			}

			return x[3];
		}
		public static void Main (string[] args)
		{
			for (int i = 0; i <= 10; i++) {
				Console.WriteLine ("x_rec ({0}) = {1}", i, x_rec(i));
				Console.WriteLine ("x_iter({0}) = {1}", i, x_iter (i));
				Console.WriteLine ();
			}
		}
	}
}
