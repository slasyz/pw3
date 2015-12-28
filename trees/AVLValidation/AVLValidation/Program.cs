using System;
//using System.Linq;
using System.Collections.Generic;

namespace AVLValidation
{
	public class Node
	{
		public Node ChildLeft = null;
		public Node ChildRight = null;
		public int Value;

		public Node(int value) : this(value, null, null) { }

		public Node(int value, Node leftChild, Node rightChild)
		{
			Value = value;
			ChildLeft = leftChild;
			ChildRight = rightChild;
		}

		public int MaxHeight
		{
			get {
				int max = 1;
				if (ChildLeft != null)
					if (ChildLeft.MaxHeight + 1 > max)
						max = ChildLeft.MaxHeight + 1;
				if (ChildRight != null)
					if (ChildRight.MaxHeight + 1 > max)
						max = ChildRight.MaxHeight + 1;
				return max;
			}
			set {}
		}

		public bool TreeSmallerThan(int value)
		{
			if (Value > value)
				return false;
			if (ChildLeft != null)
				if (!ChildLeft.TreeSmallerThan(value))
					return false;
			if (ChildRight != null)
				if (!ChildRight.TreeSmallerThan (value))
					return false;
			return true;
		}

		public bool TreeBiggerThan(int value)
		{
			if (Value < value)
				return false;
			if (ChildLeft != null)
				if (!ChildLeft.TreeBiggerThan(value))
					return false;
			if (ChildRight != null)
				if (!ChildRight.TreeBiggerThan (value))
					return false;
			return true;
		}

		public bool CheckIfBST ()
		{
			if (ChildLeft != null)
				if (!ChildLeft.TreeSmallerThan (Value))
					return false;
			if (ChildRight != null)
				if (!ChildRight.TreeBiggerThan (Value))
					return false;
			return true;
		}

		public bool CheckIfAVL ()
		{
			if (!CheckIfBST ())
				return false;

			if (ChildLeft == null && ChildRight == null)
				return true;

			if (ChildLeft == null)
				return ChildRight.MaxHeight <= 1;
			if (ChildRight == null)
				return ChildLeft.MaxHeight <= 1;

			return Math.Abs (ChildLeft.MaxHeight - ChildRight.MaxHeight) <= 1;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			int n;
			List<Node> nodes = new List<Node> ();
			Console.Write ("Введите количество вершин: ");
			n = int.Parse (Console.ReadLine ());

			for (int i = 0; i < n; i++) {
				Console.Write ("Введите значение вершины {0}: ", i + 1);
				int value = int.Parse (Console.ReadLine ());
				nodes.Add(new Node(value));
			}

			for (int i = 0; i < n; i++) {
				Console.Write ("Введите вершины, выходящие из вершины номер {0}: ", i + 1);
				string nodesStr = Console.ReadLine ();
				string[] nodesStrArr = nodesStr.Trim().Split (' ');
				string childLeft = nodesStrArr [0];
				string childRight = nodesStrArr [1];

				if (childLeft != "0")
					nodes [i].ChildLeft = nodes [int.Parse(childLeft) - 1];
				if (childRight != "0")
					nodes [i].ChildRight = nodes [int.Parse(childRight) - 1];
			}

			for (int i = 0; i < n; i++) {
				Console.WriteLine ("Высота дерева, начинающегося с вершины {0}, равна {1}", i + 1, nodes[i].MaxHeight);
			}
			for (int i = 0; i < n; i++) {
				Console.WriteLine ("Дерево, начинающееся с вершины {0} - {1}", i + 1, nodes[i].CheckIfBST() ? "BST" : "не BST");
			}

			Console.WriteLine ();
			Console.WriteLine ("Дерево {0} АВЛ-деревом", nodes[0].CheckIfAVL() ? "является" : "не является");
		}
	}
}
