using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace AVLValidation
{
	[TestFixture()]
	public class AVLValidationTests
	{
		private Node MakeSimpleAVLTree()
		{
			Node el9 = new Node (55, null, null);     //         1
			Node el8 = new Node (10, null, null);     //       /  \
			Node el7 = new Node (80, null, null);     //     2     3
			Node el6 = new Node (60, el9, null);      //    / \   / \
			Node el5 = new Node (37, null, null);     //   4   5 6  7
			Node el4 = new Node (17, el8, null);      //  /     /
			Node el3 = new Node (75, el6, el7);       // 8     9
			Node el2 = new Node (25, el4, el5);       //
			Node el1 = new Node (50, el2, el3);       //

			return el1;
		}

		[Test()]
		public void CheckNonBSTTree ()
		{
			Node tree = MakeSimpleAVLTree();
			Node el11 = new Node (2, null, null);
			Node el10 = new Node (1000, el11, null);
			// 1 -> 2   -> 4      -> 8
			tree.ChildLeft.ChildLeft.ChildLeft.ChildLeft = el10;
			Assert.IsTrue(!tree.CheckIfBST());
		}

		[Test()]
		public void CheckAVLTree ()
		{
			Node tree = MakeSimpleAVLTree();
			Assert.AreEqual (true, tree.CheckIfAVL ());
		}

		[Test()]
		public void CheckAVLTreeForEmpty ()
		{
			Node tree = new Node(1, new Node(3, new Node(2), null), null);
			Assert.AreEqual (true, tree.CheckIfBST ());
		}


		[Test()]
		public void CheckNonAVLTree ()
		{
			Node tree = MakeSimpleAVLTree();
			Node el11 = new Node (2, null, null);
			Node el10 = new Node (5, el11, null);
			// 1 -> 2   -> 4      -> 8
			tree.ChildLeft.ChildLeft.ChildLeft.ChildLeft = el10;
			Assert.IsTrue(!tree.CheckIfAVL() && tree.CheckIfBST());
		}
	}
}

