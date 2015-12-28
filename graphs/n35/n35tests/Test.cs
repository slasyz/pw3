using NUnit.Framework;
using System;
using System.Collections.Generic;
using n35;

namespace n35tests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void CheckSomeGraph ()
		{
			int n = 5;
			List<List<int>> pathsList = new List<List<int>> {
				new List<int> { 1, 2, 3, 4, 5 },
				new List<int> { 2, 4 },
				new List<int> { 3, 5 },
			};
			int[,] expected = new int[5,5] { {0, 1, 0, 0, 0}, {0, 0, 1, 1, 0}, {0, 0, 0, 1, 1}, {0, 0, 0, 0, 1}, {0, 0, 0, 0, 0} };
			int[,] actual = MainClass.MakeGraph (n, pathsList);

			string strExpected = "";
			string strActual = "";

			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
					strExpected += String.Format("{0} ", expected[i,j]);
					strActual += String.Format("{0} ", actual[i,j]);
				}
				strExpected += "\n";
				strActual += "\n";
			}
			
			Assert.AreEqual(strExpected, strActual);
		}
	}
}

