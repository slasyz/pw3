using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using ListLibrary;

namespace ListLibraryTests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void SearchTest ()
		{
			MyList l4 = new MyList(new Node(3, new Node(4, new Node(5, new Node(6)))));
			MyList l3 = new MyList(new Node(2, new Node(1, new Node(3, new Node(4)))), l4);
			MyList l2 = new MyList(new Node(4, new Node(5, new Node(6, new Node(2)))), l3);
			MyList l1 = new MyList(new Node(1, new Node(2, new Node(3, new Node(4)))), l2);
			
			var lOther = new List<int> { 2, 1, 3, 4 };

			MyListOfLists a = new MyListOfLists (l1);

			//Assert.IsTrue ((b.Head.Next.Next.Next.Head == null));
			Assert.AreEqual (2, a.FindIndex (lOther));
		}

		[Test()]
		public void DeleteTest ()
		{
			MyList l4 = new MyList(new Node(3, new Node(4, new Node(5, new Node(6)))));
			MyList l3 = new MyList(new Node(2, new Node(1, new Node(3, new Node(4)))), l4);
			MyList l2 = new MyList(new Node(4, new Node(5, new Node(6, new Node(2)))), l3);
			MyList l1 = new MyList(new Node(1, new Node(2, new Node(3, new Node(4)))), l2);

			var lOther = new List<int> { 2, 1, 3, 4 };

			MyListOfLists a = new MyListOfLists (l1);
			a.DeleteList (lOther);

			//Assert.IsTrue ((b.Head.Next.Next.Next.Head == null));
			Assert.AreEqual(3, a.Count);
		}

		[Test()]
		public void DeleteTest2 ()
		{
			MyList l4 = new MyList(new Node(3, new Node(4, new Node(5, new Node(6)))));
			MyList l3 = new MyList(new Node(2, new Node(1, new Node(3, new Node(4)))), l4);
			//MyList l2 = new MyList(new Node(4, new Node(5, new Node(6, new Node(2)))), l3);
			//MyList l1 = new MyList(new Node(1, new Node(2, new Node(3, new Node(4)))), l2);

			//var lOther = new List<int> { 2, 1, 3, 4 };

			MyListOfLists a = new MyListOfLists (l3);
			a.DeleteListByIndex (1);

			//Assert.IsTrue ((b.Head.Next.Next.Next.Head == null));
			Assert.IsTrue(a.Count == 1);
		}


		[Test()]
		public void InsertTest ()
		{
			MyList l4 = new MyList(new Node(3, new Node(4, new Node(5, new Node(6)))));
			MyList l3 = new MyList(new Node(2, new Node(1, new Node(3, new Node(4)))), l4);
			MyList l2 = new MyList(new Node(4, new Node(5, new Node(6, new Node(2)))), l3);
			MyList l1 = new MyList(new Node(1, new Node(2, new Node(3, new Node(4)))), l2);

			MyList lOther = new MyList(new Node(9, new Node(8, new Node(7, new Node(6)))));

			MyListOfLists a = new MyListOfLists (l1);
			a.InsertListByIndex (2, lOther);

			Assert.IsTrue ((a.Count == 5) && 
			               ReferenceEquals(a[2], lOther));
		}

		[Test()]
		public void SplitTest ()
		{
			MyList l4 = new MyList(new Node(3, new Node(4, new Node(5, new Node(6)))));
			MyList l3 = new MyList(new Node(2, new Node(1, new Node(3, new Node(4)))), l4);
			MyList l2 = new MyList(new Node(4, new Node(5, new Node(6, new Node(2)))), l3);
			MyList l1 = new MyList(new Node(1, new Node(2, new Node(3, new Node(4)))), l2);

			MyListOfLists a = new MyListOfLists (l1);
			MyListOfLists b;

			a.SplitByElement (2, out b);

			//Assert.IsTrue ((b.Head.Next.Next.Next.Head == null));
			Assert.IsTrue ((a[0].Count == 1) && (b[0].Count == 2) && 
				           (a[1].Count == 3) && (b[1].Count == 0) &&
			               (a[2].Count == 0) && (b[2].Count == 3) &&
			               (a[3].Count == 4) && (b[3].Count == 0));
		}

		[Test()]
		public void ListCloneTest ()
		{
			MyList a = new MyList(new Node(3, new Node(4, new Node(5, new Node(6)))));
			MyList b = a.Clone ();

			Assert.IsTrue ((b[3].Value == 6) &&
			               !ReferenceEquals(b[3], a[3]));
		}

		[Test()]
		public void CloneTest ()
		{
			MyList l4 = new MyList(new Node(3, new Node(4, new Node(5, new Node(6)))));
			MyList l3 = new MyList(new Node(2, new Node(1, new Node(3, new Node(4)))), l4);
			MyList l2 = new MyList(new Node(4, new Node(5, new Node(6, new Node(2)))), l3);
			MyList l1 = new MyList(new Node(1, new Node(2, new Node(3, new Node(4)))), l2);

			MyListOfLists a = new MyListOfLists (l1);
			MyListOfLists b = a.Clone();

			Assert.IsTrue ((b[3][3].Value == 6) &&
			               !ReferenceEquals(a[3][3], b[3][3]));

		}
	}
}

