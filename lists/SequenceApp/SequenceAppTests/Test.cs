using NUnit.Framework;
using System;
using System.Collections.Generic;
using SequenceApp;

namespace SequenceAppTests
{
	[TestFixture()]
	public class Test
	{
		public static bool CheckIfAscending(List<int> list)
		{
			for (int i = 0; i < list.Count - 1; i++)
			{
				if (list[i] > list[i + 1])
				{
					return false;
				}
			}
			return true;
		}

		[Test()]
		public void CheckEmptySequence ()
		{
			MySequence seq = new MySequence (null);

			Node startNode;
			int expectedLength = 0;
			int length = seq.SearchForLIS(out startNode);
			Assert.AreEqual(expectedLength, length);
		}

		[Test()]
		public void CheckDescendingSequence ()
		{
			MySequence seq = new MySequence (new Node (10, new Node (9, new Node (8, new Node (7, new Node (6, new Node (5, new Node (4, new Node (3, new Node (2, new Node (1, new Node (0))))))))))));

			Node startNode;
			int expectedLength = 1;
			int length = seq.SearchForLIS(out startNode);
			Assert.AreEqual(expectedLength, length);
		}

		[Test()]
		public void CheckGenericSequence ()
		{
			MySequence seq = new MySequence (new Node (1, new Node (2, new Node (3, new Node (1, new Node (2, new Node (3, new Node (4, new Node (5, new Node (6, new Node (3, new Node (2, new Node (1)))))))))))));

			Node startNode;
			int expectedLength = 6;
			int length = seq.SearchForLIS(out startNode);
			Assert.AreEqual(expectedLength, length);
		}

		[Test()]
		public void CheckGenericSequence1 ()
		{
			MySequence seq = new MySequence (new Node (1, new Node (1, new Node (1,
											new Node (1, new Node (1, new Node (1, 
			                                    new Node (1, new Node (1, new Node (1, 
			                                    new Node (1, new Node (1, new Node (1)))))))))))));

			Node startNode;
			int expectedLength = 12;
			int length = seq.SearchForLIS(out startNode);
			Assert.AreEqual(expectedLength, length);
		}

		[Test()]
		public void CheckGenericSequence2 ()
		{
			MySequence seq = new MySequence (new Node (1, new Node (2, new Node (3,
			                                    new Node (1, new Node (2, new Node (3, 
			                                    new Node (1, new Node (2, new Node (3, 
			                                    new Node (1, new Node (1, new Node (1)))))))))))));

			Node startNode;
			int expectedLength = 3;
			int length = seq.SearchForLIS(out startNode);
			Assert.AreEqual(expectedLength, length);
		}


	}
}

