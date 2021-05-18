namespace Tartaros.Tests.Collections
{
	using NUnit.Framework;
	using System.Collections.Generic;

	public class Test_RemoveLastOccurenceElement
	{
		[Test]
		public void When_NoOccurence_Should_DoNotTouchTheQueue()
		{
			Queue<int> expectedQueue = ConstructQueueWithThreeZero();
			Queue<int> actualQueue = new Queue<int>(expectedQueue);

			actualQueue = actualQueue.RemoveLastOccurenceOf(1);

			Assert.AreEqual(expectedQueue, actualQueue);
		}

		[Test]
		public void When_OnlyOccurences_Should_RemoveLastElement()
		{
			Queue<int> expectedQueue = ConstructQueueWithThreeZero();
			expectedQueue.Dequeue();

			Queue<int> actualQueue = new Queue<int>(ConstructQueueWithThreeZero());

			actualQueue = actualQueue.RemoveLastOccurenceOf(0);

			Assert.AreEqual(expectedQueue, actualQueue);
		}

		[Test]
		public void When_OneOccurenceAtTheStart_Should_RemoveIt()
		{
			Queue<int> expectedQueue = new Queue<int>();
			expectedQueue.Enqueue(1);
			expectedQueue.Enqueue(1);

			Queue<int> actualQueue = new Queue<int>();
			actualQueue.Enqueue(0);
			actualQueue.Enqueue(1);
			actualQueue.Enqueue(1);


			actualQueue = actualQueue.RemoveLastOccurenceOf(0);

			Assert.AreEqual(expectedQueue, actualQueue);
		}

		[Test]
		public void When_OneOccurenceAtTheEnd_Should_RemoveIt()
		{
			Queue<int> expectedQueue = new Queue<int>();
			expectedQueue.Enqueue(1);
			expectedQueue.Enqueue(1);

			Queue<int> actualQueue = new Queue<int>();
			actualQueue.Enqueue(1);
			actualQueue.Enqueue(1);
			actualQueue.Enqueue(0);


			actualQueue = actualQueue.RemoveLastOccurenceOf(0);

			Assert.AreEqual(expectedQueue, actualQueue);
		}

		[Test]
		public void When_OneOccurenceInTheMiddle_Should_RemoveIt()
		{
			Queue<int> expectedQueue = new Queue<int>();
			expectedQueue.Enqueue(1);
			expectedQueue.Enqueue(1);

			Queue<int> actualQueue = new Queue<int>();
			actualQueue.Enqueue(1);
			actualQueue.Enqueue(0);
			actualQueue.Enqueue(1);

			actualQueue = actualQueue.RemoveLastOccurenceOf(0);

			Assert.AreEqual(expectedQueue, actualQueue);
		}
		
		[Test]
		public void When_TwoOccurence_Should_RemoveLast()
		{
			Queue<int> actualQueue = new Queue<int>(); // 01101
			actualQueue.Enqueue(0);
			actualQueue.Enqueue(1);
			actualQueue.Enqueue(1);
			actualQueue.Enqueue(0);
			actualQueue.Enqueue(1);

			Queue<int> expectedQueue = new Queue<int>(); // 0111
			expectedQueue.Enqueue(0);
			expectedQueue.Enqueue(1);
			expectedQueue.Enqueue(1);
			expectedQueue.Enqueue(1);

			actualQueue = actualQueue.RemoveLastOccurenceOf(0);

			Assert.AreEqual(expectedQueue, actualQueue);
		}

		private static Queue<int> ConstructQueueWithThreeZero()
		{
			Queue<int> expectedQueue = new Queue<int>();
			expectedQueue.Enqueue(0);
			expectedQueue.Enqueue(0);
			expectedQueue.Enqueue(0);
			return expectedQueue;
		}
	}
}
