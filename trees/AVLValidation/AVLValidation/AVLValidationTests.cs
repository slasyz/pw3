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
			Node el9 = new Node ();
			Node el8 = new Node ();
			Node el7 = new Node ();
			Node el6 = new Node (el9);
			Node el5 = new Node ();
			Node el4 = new Node (el8);
			Node el3 = new Node (el6, el7);
			Node el2 = new Node (el4, el5);
			Node el1 = new Node (el1, el2);

			return el1;
		}

		[Test()]
		public void CheckNonBinaryTree ()
		{
			Node tree = new Node(List<Node>(new Node(), new Node(), new Node()));
			Assert.AreEqual (false, tree.CheckIfAVL ());
		}

		[Test()]
		public void CheckAVLTree ()
		{
			Node tree = MakeSimpleAVLTree();
			Assert.AreEqual (true, tree.CheckIfAVL ());
		}

		[Test()]
		public void CheckNonAVLTree ()
		{
			Node tree = MakeSimpleAVLTree();
			Node el = new Node ();
			// 1 -> 2        -> 4        -> 8
			tree.Children [0].Children [0].Children [0].Children.Add (el);
			Assert.AreEqual (false, tree.CheckIfAVL ());
		}
	}
}

