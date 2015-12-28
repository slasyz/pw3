using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace SequenceApp
{
	public class Node
	{
		public int Value;
		public Node Next = null;

		public Node(int value) : this(value, null) { }

		public Node(int value, Node next)
		{
			Value = value;
			Next = next;
		}
	}

	public class MySequence
	{
		public Node Head = null;

		public MySequence() : this(null)
		{
		}
		public MySequence(Node head)
		{
			Head = head;
		}

		public void Add(int value)
		{
			Node newNode = new Node (value, null);

			if (Head == null)
				Head = newNode;
			else {
				Node currentNode = Head;
				while (currentNode.Next != null)
					currentNode = currentNode.Next;

				currentNode.Next = newNode;
			}
		}

		public int SearchForLIS(out Node startNode)
		{
			if (Head == null) {
				startNode = null;
				return 0;
			}

			Node currentNode = Head;
			Node currentStartNode = Head;
			Node resultStartNode = Head;
			int max = 0;
			int currentLength = 1;
			while (currentNode.Next != null) {
				if (currentNode.Value > currentNode.Next.Value) {
					if (currentLength > max) {
						resultStartNode = currentStartNode;
						max = currentLength;
					}
					currentLength = 1;
					currentStartNode = currentNode.Next;
					currentNode = currentStartNode;
				} else {
					currentNode = currentNode.Next;
					currentLength++;
				}
			}
			if (currentLength > max)
				max = currentLength;

			startNode = resultStartNode;
			return max;
		}
	}

	public static class Program
	{
		static void Main(string[] args)
		{
			int n;

			Console.WriteLine("Введите количество элементов: ");
			n = int.Parse(Console.ReadLine());
			Console.WriteLine("Введите {0} элементов, каждый с новой строки: ", n);
			MySequence seq = new MySequence ();
			for (int i = 0; i < n; i++)
			{
				int newEl = int.Parse(Console.ReadLine());
				seq.Add(newEl);
			}
			//n = 8;
			//origList = new List<int> { 1, 3, 2, 5, 4, 10, 100, 50 };

			int length;
			Node currentNode;
			length = seq.SearchForLIS (out currentNode);
			Console.WriteLine("Наибольшая возрастающая подпоследовательность: ");
			for (int i = 0; i < length; i++) {
				Console.Write ("{0} ", currentNode.Value);
				currentNode = currentNode.Next;
			}
			Console.ReadLine();
		}
	}
}
