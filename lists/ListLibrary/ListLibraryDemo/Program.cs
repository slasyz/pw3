using System;
using System.Collections.Generic;
using ListLibrary;

namespace ListLibraryDemo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MyList l4 = new MyList(new Node(3, new Node(4, new Node(5, new Node(6)))));
			MyList l3 = new MyList(new Node(2, new Node(1, new Node(3, new Node(4)))), l4);
			MyList l2 = new MyList(new Node(4, new Node(5, new Node(6, new Node(2)))), l3);
			MyList l1 = new MyList(new Node(1, new Node(2, new Node(3, new Node(4)))), l2);

			MyListOfLists a = new MyListOfLists (l1);
			MyListOfLists b = a.Clone();

			Console.Write (b.Head.Next.Next.Next.Head.Next.Next.Next.Value);
		}
	}
}
