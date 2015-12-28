using System;
using System.Collections.Generic;
//using System.Linq;

namespace ListLibrary
{
	public class SublistNotFoundException: System.Exception
	{
	}

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

	public class MyList
	{
		public Node Head;
		public MyList Next;

		public MyList() : this(null)
		{
		}

		public MyList(Node head, MyList next = null)
		{
			Head = head;
			Next = next;
		}

		public int Count {
			get {
				int res = 0;
				Node currentElement = Head;
				while (currentElement != null) {
					currentElement = currentElement.Next;
					res++;
				}

				/*
				Node currentElement = Head;
				if (currentElement == null)
					return 0;

				int res = 1;
				while (currentElement.Next != null) {
					currentElement = currentElement.Next;
					res++;
				}*/

				return res;
			}
			set {;}
		}

		public Node this[int key]
		{
			get {
				Node element = Head;
				int i = 0;
				while ((i < key) && (element.Next != null)) {
					i++;
					element = element.Next;
				}
				return element;
			}
			set {;}
		}

		public bool Equals(List<int> list)
		{
			if (Count != list.Count)
				return false;

			Node currentElement = Head;
			foreach (var el in list) {
				if (currentElement.Value != el)
					return false;
				currentElement = currentElement.Next;
			}
			return true;
		}

		public MyList Clone()
		{
			if (Head == null)
				return new MyList ();

			Node newHead = new Node (Head.Value, Head.Next);
			
			Node currentNode = newHead;
			Node currentOldNode = Head;
			while (currentOldNode.Next != null) {
				Node newNode = new Node (currentOldNode.Next.Value, currentOldNode.Next.Next);
				currentOldNode = currentOldNode.Next;
				currentNode.Next = newNode;
				currentNode = newNode;
			}
			return new MyList(newHead);
		}
	}

	public class MyListOfLists
	{
		public MyList Head;

		public MyListOfLists() : this(null)
		{
		}
		public MyListOfLists(MyList head)
		{
			Head = head;
		}

		public MyList this[int key]
		{
			get {
				MyList list = Head;
				int i = 0;
				while ((i < key) && (list.Next != null)) {
					i++;
					list = list.Next;
				}
				return list;
			}
			set {;}
		}

		public int Count {
			get {
				int res = 0;
				MyList tail = Head;
				while (tail != null) {
					res++;
					tail = tail.Next;
				}
				return res;
			}
			set {;}
		}

		public void Add(MyList list)
		{
			MyList tail = Head;
			if (tail == null)
				Head = list;
			else {
				while (tail.Next != null)
					tail = tail.Next;
				tail.Next = list;
			}
		}

		public int FindIndex(List<int> subList)
		{
			MyList currentList = Head;
			if (currentList == null)
				return -1;

			int index = 0;
			do{
				if (currentList.Equals (subList))
					return index;
				index++;
				currentList = currentList.Next;
			} while (currentList != null);

			return -1;
		}

		public void DeleteList(List<int> subList)
		{
			DeleteListByIndex (FindIndex (subList));
		}

		public void DeleteListByIndex(int index)
		{
			MyList currentList = Head;
			if (currentList == null)
				throw new SublistNotFoundException();

			if (index == 0)
				Head = currentList.Next;

			for (int i = 0; i < index - 1; i++) {
				if (currentList.Next == null)
					throw new SublistNotFoundException();
				currentList = currentList.Next;
			}

			currentList.Next = currentList.Next.Next;
		}

		public void InsertListByIndex(int index, MyList list)
		{
			if (index == 0) {
				list.Next = Head;
				Head = list;
				return;
			}

			MyList currentList = Head;
			for (int i = 0; i < index - 1; i++) {
				if (currentList == null)
					throw new SublistNotFoundException();
				currentList = currentList.Next;
			}
			
			list.Next = currentList.Next;
			currentList.Next = list;
		}

		public void Concatenate (MyListOfLists second) {
			if (Head == null) {
				Head = second.Head;
			} else {
				MyList tail = Head;
				while (tail.Next != null)
					tail = tail.Next;

				tail.Next = second.Head;
			}
		}

		public void SplitByElement(int el, out MyListOfLists secondListOfLists)
		{
			secondListOfLists = new MyListOfLists ();

			MyList currentList = Head;
			while (currentList != null) {
				MyList secondList = new MyList ();
				secondListOfLists.Add (secondList);

				Node currentNode = currentList.Head;
				if (currentNode == null) {
					// ничего
				} else if (currentNode.Value == el) {
					currentList.Head = null;
					secondList.Head = currentNode.Next;
				} else {
					while (currentNode.Next != null) {
						if (currentNode.Next.Value == el) {
							secondList.Head = currentNode.Next.Next;
							currentNode.Next = null;
							break;
						}
						currentNode = currentNode.Next;
					}
				}
				currentList = currentList.Next;
			}
		}

		public MyListOfLists Clone()
		{
			if (Head == null)
				return new MyListOfLists ();

			MyList newHead = new MyList (Head.Head, Head.Next);

			MyList currentList = newHead;
			MyList currentOldList = Head;
			while (currentOldList.Next != null) {
				MyList newList = currentOldList.Next.Clone();
				newList.Next = currentOldList.Next.Next;
				currentOldList = currentOldList.Next;
				currentList.Next = newList;
				currentList = newList;
			}
			return new MyListOfLists(newHead);
		}
	}
}
