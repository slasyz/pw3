using System;

namespace n33
{
	public static class MainClass
	{
		public static void GetMaxIJK(int n, int [,] graph, out int maxSum, out int ir, out int jr, out int kr)
		{
			maxSum = 0;
			ir = 0; jr = 0; kr = 0;
			// Перебираем каждую тройку различных вершин
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
					if (i == j)
						continue;
					if (graph [i, j] == 0)
						continue;

					for (int k = 0; k < n; k++) {
						if ((k == i) | (k == j))
							continue;
						if (graph [j, k] == 0)
							continue;

						int newSum = graph[i, j] + graph[j, k];
						if (newSum > maxSum) {
							maxSum = newSum;
							ir = i;
							jr = j;
							kr = k;
						}
					}
				}
			}
			ir++; jr++; kr++;
		}

		public static void Main (string[] args)
		{
			int n;
			int[,] graph;

			// считываем граф с экрана
			Console.Write ("Введите количество элементов в графе: ");
			n = int.Parse (Console.ReadLine ());
			graph = new int[n, n];
			for (int i = 0; i < n; i++) {
				Console.Write ("Введите {0}-ю строку: ", i+1);
				string str = Console.ReadLine ();
				string[] elements = str.Split (' ');
				for (int j = 0; j < n; j++)
					graph[i, j] = int.Parse(elements[j]);
			}
			Console.WriteLine ();

			// получаем результат
			int ir = 0, jr = 0, kr = 0;
			int maxSum = 0;
			GetMaxIJK (n, graph, out maxSum, out ir, out jr, out kr);

			Console.WriteLine ("Наибольшие рёбра - это {0}-{1} и {1}-{2} с суммарной длиной {3}", ir, jr, kr, maxSum);
		}
	}
}
