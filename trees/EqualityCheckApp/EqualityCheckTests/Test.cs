using NUnit.Framework;
using System;
using EqualityCheckApp;

namespace EqualityCheckTests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void CheckEmptyEqualTrees ()
		{
			Node node1 = new Node (1, null, null);
			Node node2 = new Node (1, null, null);

			Assert.IsTrue (node1.Equals(node2));
		}

		[Test()]
		public void CheckEmptyNonEqualTrees ()
		{
			Node node1 = new Node (1, null, null);
			Node node2 = new Node (2, null, null);

			Assert.IsFalse (node1.Equals(node2));
		}
		
		[Test()]
		public void CheckEqualTrees ()
		{
			Node a6 = new Node (51, null, null);
			Node a5 = new Node (50, a6, null);
			Node a4 = new Node (49, null, null);
			Node a3 = new Node (47, a4, a5);
			Node a2 = new Node (46, null, null);
			Node a1 = new Node (45, a2, a3);
			
			Node b6 = new Node (51, null, null);
			Node b5 = new Node (50, b6, null);
			Node b4 = new Node (49, null, null);
			Node b3 = new Node (47, b4, b5);
			Node b2 = new Node (46, null, null);
			Node b1 = new Node (45, b2, b3);

			Assert.IsTrue (a1.Equals(b1));
		}

		[Test()]
		public void CheckInvertedTrees ()
		{
			Node a6 = new Node (51, null, null);
			Node a5 = new Node (50, a6, null);
			Node a4 = new Node (49, null, null);
			Node a3 = new Node (47, a4, a5);
			Node a2 = new Node (46, null, null);
			Node a1 = new Node (45, a2, a3);

			Node b6 = new Node (51, null, null);
			Node b5 = new Node (50, null, b6);
			Node b4 = new Node (49, null, null);
			Node b3 = new Node (47, b5, b4);
			Node b2 = new Node (46, null, null);
			Node b1 = new Node (45, b3, b2);

			Assert.IsTrue (a1.Equals(b1));
		}

		[Test()]
		public void CheckNonEqualTrees ()
		{
			Node a6 = new Node (51, null, null);
			Node a5 = new Node (50, a6, null);
			Node a4 = new Node (49, null, null);
			Node a3 = new Node (47, a4, a5);
			Node a2 = new Node (46, null, null);
			Node a1 = new Node (45, a2, a3);

			Node b6 = new Node (51, null, null);
			Node b5 = new Node (50, null, b6);
			Node b4 = new Node (49, null, null);
			Node b3 = new Node (10, b5, b4);
			Node b2 = new Node (46, null, null);
			Node b1 = new Node (45, b3, b2);

			Assert.IsFalse (a1.Equals(b1));
		}
	}
}

