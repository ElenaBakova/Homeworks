using System.Runtime.CompilerServices;

namespace PriorityQueue
{
    /// <summary>
    /// Thread-safe priority queue class
    /// </summary>
    /// <typeparam name="TValue">Type of the value</typeparam>
    public class PriorityQueue<TValue>
    {
        private PriorityQueue<TValue, int> queue = new();
        private object lockObject = new ();

        /// <summary>
        /// True if queue is empty 
        /// </summary>
        public bool Empty
            => queue.Count == 0;

        /// <summary>
        /// Returns size of the queue
        /// </summary>
        public int Size
            => queue.Count;

        /// <summary>
        /// Adds new element to the queue
        /// </summary>
        /// <param name="value">New element value</param>
        /// <param name="priority">Priority of new element</param>
        public void Enqueue(TValue value, int priority)
        {
            lock (queue)
            {
                queue.Enqueue(value, priority);
                Monitor.PulseAll(lockObject);
            }
        }

        /// <summary>
        /// Deletes element with highest priority
        /// </summary>
        /// <returns>Value of deleted element</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public TValue Dequeue()
        {
            while (Empty)
            {
                Monitor.Wait(lockObject);
            }
            var result = queue.Dequeue();
            return result;
        }
    }
}
