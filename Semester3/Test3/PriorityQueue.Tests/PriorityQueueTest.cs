using NUnit.Framework;
using System.Threading.Tasks;

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
            Parallel.Invoke(() => queue.Enqueue(0, 1));
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void EnqueueTest()
        {
            Parallel.For(0, 10, index => queue.Enqueue(index, 10 - index));
            var result = true;
            for (int i = 0; i < 10; i++)
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
    }
}