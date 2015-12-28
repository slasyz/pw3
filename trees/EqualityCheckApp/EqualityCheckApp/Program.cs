using System;
using System.Collections.Generic;

namespace EqualityCheckApp
{
	public class Node
	{
		public int Value;
		public Node ChildLeft;
		public Node ChildRight;

		public Node(int value, Node childLeft = null, Node childRight = null)
		{
			Value = value;
			ChildLeft = childLeft;
			ChildRight = childRight;
		}

		public override bool Equals(Object obj)
		{
			Node other = obj as Node;
			if (other == null)
				return false;

			if (Value != other.Value)
				return false;
	
			if (ChildLeft == null) {
				if (ChildRight == null)
					return (other.ChildLeft == null) && (other.ChildRight == null);
				else
					return (other.ChildLeft == null) && (ChildRight.Equals (other.ChildRight)) || // normal tree
						   (other.ChildRight == null) && (ChildRight.Equals (other.ChildLeft));   // inverted tree
			} else {
				if (ChildRight == null)
					return ChildLeft.Equals(other.ChildLeft) && (other.ChildRight == null) || // normal tree
						   ChildLeft.Equals(other.ChildRight) && (other.ChildLeft == null);   // inverted tree
				else
					return (ChildLeft.Equals(other.ChildLeft)) && (ChildRight.Equals(other.ChildRight)) ||
			     		   (ChildLeft.Equals(other.ChildRight)) && (ChildRight.Equals(other.ChildLeft));
			}
		}
	}
	class MainClass
	{
		public static void Main(string[] args)
		{
			Node a5 = new Node (50, null, null);
			Node a4 = new Node (49, null, null);
			Node a3 = new Node (47, a4, a5);
			Node a2 = new Node (46, null, null);
			Node a1 = new Node (45, a2, a3);

			Node b5 = new Node (50, null, null);
			Node b4 = new Node (49, null, null);
			Node b3 = new Node (47, b4, b5);
			Node b2 = new Node (46, null, null);
			Node b1 = new Node (45, b2, b3);

			Console.WriteLine("Первое дерево {0} второму. ", (a1.Equals(b1)) ? "равно" : "не равно");
		}

		public static void Main1 (string[] args)
		{
			int n1, n2;
			List<Node> nodes1;
			List<Node> nodes2;
			Console.Write ("Введите количество элементов первого дерева: ");
			n1 = int.Parse(Console.ReadLine());
			Console.Write ("Введите количество элементов второго дерева: ");
			n2 = int.Parse(Console.ReadLine());

			nodes1 = new List<Node>();
			for (int i = 0; i < n1; i++) {
				Console.Write ("Введите значение {0} элемента первого дерева: ", i + 1);
				int value = int.Parse(Console.ReadLine());
				nodes1.Add (new Node (value));
			}
			nodes2 = new List<Node>();
			for (int i = 0; i < n2; i++) {
				Console.Write ("Введите значение {0} элемента второго дерева: ", i + 1);
				int value = int.Parse(Console.ReadLine());
				nodes2.Add (new Node (value));
			}

			for (int i = 0; i < n1; i++) {
				Console.Write ("Введите номера вершин, выходящих из {0} элемента первого дерева: ", i + 1);
				string[] values = Console.ReadLine().Split(' ');
				nodes1[i].ChildLeft = nodes1[int.Parse(values[0])];
				nodes1[i].ChildRight = nodes1[int.Parse(values[1])];
			}
			for (int i = 0; i < n2; i++) {
				Console.Write ("Введите номера вершин, выходящих из {0} элемента второго дерева: ", i + 1);
				string[] values = Console.ReadLine().Split(' ');
				nodes2[i].ChildLeft = nodes2[int.Parse(values[0])];
				nodes2[i].ChildRight = nodes2[int.Parse(values[1])];
			}

			Console.WriteLine("Первое дерево {0} второму. ", (nodes1[0].Equals(nodes2[0])) ? "равно" : "не равно");
		}
	}
}
