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
            Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
        }
        
        [Test]
        public void EnqueueTest()
        {
            queue.Enqueue(3, 1);
            queue.Enqueue(5, 0);
            queue.Enqueue(1, 4);
            queue.Enqueue(4, 1);
            queue.Enqueue(1, 5);
            var result = true;
            for (int i = 1; i < 6; i++)
            {
                result &= queue.Dequeue() == i;
            }
            Assert.IsTrue(result);
        }
    }
}