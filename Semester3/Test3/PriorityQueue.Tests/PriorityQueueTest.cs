using NUnit.Framework;

namespace PriorityQueue.Tests
{
    public class Tests
    {
        private PriorityQueue<int> queue;

        [SetUp]
        public void Setup()
        {
            queue = new();
        }

        [Test]
        public void DeleteFromEmptyQueueTest()
        {
            var result = queue.Dequeue();
            int element = 1;
            queue.Enqueue(element, 2);
            Assert.AreEqual(result, element);
        }

        [Test]
        public void EnqueueTest()
        {
            queue.Enqueue(3, 1);
            queue.Enqueue(5, 0);
            queue.Enqueue(2, 4);
            queue.Enqueue(4, 1);
            queue.Enqueue(1, 5);
            var result = true;
            for (int i = 1; i < 6; i++)
            {
                result &= queue.Dequeue() == i;
            }
            Assert.IsTrue(result);
        }

        [Test]
        public void AfterEnqueueSizeShoulBeIncreased()
        {
            queue.Enqueue(3, 1);
            Assert.AreEqual(1, queue.Size);
        }

        [Test]
        public void AfterDequeueSizeShoulBeDecreased()
        {
            queue.Enqueue(3, 1);
            queue.Enqueue(5, 0);
            queue.Enqueue(2, 4);
            int oldSize = queue.Size;
            queue.Dequeue();
            Assert.AreEqual(1, oldSize - queue.Size);
        }
        
        [Test]
        public void ValueTypeStringTest()
        {
            PriorityQueue<string> queueTest = new();
            queueTest.Enqueue("c", 1);
            queueTest.Enqueue("e", 0);
            queueTest.Enqueue("b", 4);
            queueTest.Enqueue("d", 1);
            queueTest.Enqueue("a", 5);
            var result = true;
            string stringAnswer = "abcde";
            for (int i = 0; i < 5; i++)
            {
                result &= Equals(queueTest.Dequeue(), stringAnswer[i].ToString());
            }
            Assert.IsTrue(result);
        }
    }
}