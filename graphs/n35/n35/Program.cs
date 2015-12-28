using System;
using System.Collections.Generic;

namespace n35
{
	public static class MainClass
	{
		public static int[,] MakeGraph(int n, List<List<int>> pathsList)
		{
			int[,] graph = new int[n,n];
			graph = new int[n, n];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					graph [i, j] = 0;

			foreach (List<int> path in pathsList) {
				for (int i = 0; i < path.Count - 1; i++) {
					graph [path [i]-1, path [i + 1]-1] = 1;
				}
			}
			return graph;
		}

		public static void Main (string[] args)
		{
			int n;
			int[,] graph;

			Console.Write ("Введите количество элементов в графе: ");
			n = int.Parse (Console.ReadLine ());

			string str;
			List<List<int>> pathsList = new List<List<int>>();
			while (true) {
				Console.Write ("Введите путь: ");
				str = Console.ReadLine ();
				if (str == "")
					break;
				string[] elements = str.Split (' ');

				List<int> pth = new List<int>();
				foreach (string el in elements)
					pth.Add(int.Parse(el));
				pathsList.Add(pth);
			};
			Console.WriteLine ();

			graph = MakeGraph (n, pathsList);
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++)
					Console.Write ("{0} ", graph [i, j]);
				Console.WriteLine ();
			}
		}
	}
}
