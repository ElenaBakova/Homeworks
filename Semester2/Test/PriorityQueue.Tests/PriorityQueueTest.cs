using NUnit.Framework;

namespace PriorityQueue.Tests
{
    /// <summary>
    /// Prior
    /// </summary>
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
            Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
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
            Assert.AreEqual(1, queue.Size - oldSize);
        }
    }
}