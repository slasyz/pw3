using NUnit.Framework;
using System;
using n33;

namespace n33tests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void Check12345Array ()
		{
			int maxSum, ir, jr, kr;
			int[,] graph = new int[,] { {1,2,3,4,5}, {2,3,4,5,6}, {3,4,5,6,7}, {4,5,6,7,8}, {5,6,7,8,9} };
			MainClass.GetMaxIJK (5, graph, out maxSum, out ir, out jr, out kr);

			Assert.AreEqual (15, maxSum, String.Format("Неправильная сумма ({0} = {1}-{2} + {2}-{3})", maxSum, ir, jr, kr));
		}

		[Test()]
		public void CheckAnotherArray ()
		{
			int maxSum, ir, jr, kr;
			int[,] graph = new int[,] { {1,2,9,8,1}, {2,3,2,2,2}, {9,2,2,1,2}, {8,2,1,2,10}, {1,2,2,10,1} };
			MainClass.GetMaxIJK (5, graph, out maxSum, out ir, out jr, out kr);

			Assert.AreEqual (18, maxSum, String.Format("Неправильная сумма ({0} = {1}-{2} + {2}-{3})", maxSum, ir, jr, kr));
		}

		[Test()]
		public void CheckArrayWithOnlyCycle ()
		{
			int maxSum, ir, jr, kr;
			int[,] graph = new int[,] { {0,1,0,0,0}, {0,0,2,0,0}, {0,0,0,3,0}, {0,0,0,0,4}, {1,0,0,0,0} };
			MainClass.GetMaxIJK (5, graph, out maxSum, out ir, out jr, out kr);

			Assert.AreEqual (7, maxSum, String.Format("Неправильная сумма ({0} = {1}-{2} + {2}-{3})", maxSum, ir, jr, kr));
		}

		[Test()]
		public void CheckEmptyArray ()
		{
			int maxSum, ir, jr, kr;
			int[,] graph = new int[,] { {0,0,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0} };
			MainClass.GetMaxIJK (5, graph, out maxSum, out ir, out jr, out kr);

			Assert.AreEqual (0, maxSum, String.Format("Неправильная сумма ({0} = {1}-{2} + {2}-{3})", maxSum, ir, jr, kr));
		}

		[Test()]
		public void CheckArrayWithOneRib ()
		{
			int maxSum, ir, jr, kr;
			int[,] graph = new int[,] { {0,1,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0} };
			MainClass.GetMaxIJK (5, graph, out maxSum, out ir, out jr, out kr);

			Assert.AreEqual (0, maxSum, String.Format("Неправильная сумма ({0} = {1}-{2} + {2}-{3})", maxSum, ir, jr, kr));
		}

		[Test()]
		public void CheckArrayWithTwoRibs ()
		{
			int maxSum, ir, jr, kr;
			int[,] graph = new int[,] { {0,10,0,0,0}, {0,0,5,0,0}, {0,0,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0} };
			MainClass.GetMaxIJK (5, graph, out maxSum, out ir, out jr, out kr);

			Assert.AreEqual (15, maxSum, String.Format("Неправильная сумма ({0} = {1}-{2} + {2}-{3})", maxSum, ir, jr, kr));
		}
	}
}

 