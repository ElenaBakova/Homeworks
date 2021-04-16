namespace PriorityQueue
{
    /// <summary>
    /// Priority queue class
    /// </summary>
    /// <typeparam name="TValue">Type of the value</typeparam>
    public class PriorityQueue<TValue>
    {
        /// <summary>
        /// Priority queue element class 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        private class QueueElement<TValue>
        {
            public QueueElement(TValue value, int priority, QueueElement<TValue> next)
            {
                Value = value;
                Priority = priority;
                Next = next;
            }

            public TValue Value { get; set; }
            public int Priority { get; set; }
            public QueueElement<TValue> Next { get; set; }
        }

        private int size = 0;
        private QueueElement<TValue> head;

        /// <summary>
        /// Returns true is queue is empty 
        /// </summary>
        public bool Empty
            => size == 0;

        /// <summary>
        /// Returns size of the queue
        /// </summary>
        public int Size
            => size;

        /// <summary>
        /// Adds new element to the queue
        /// </summary>
        /// <param name="value">New element value</param>
        /// <param name="priority">Priority of new element</param>
        public void Enqueue(TValue value, int priority)
        {
            size++;
            if (size == 1 || head.Priority < priority)
            {
                head = new QueueElement<TValue>(value, priority, head);
                return;
            }

            var currentElement = head;
            while (currentElement.Next != null && currentElement.Next.Priority >= priority)
            {
                currentElement = currentElement.Next;
            }
            var newElement= new QueueElement<TValue>(value, priority, currentElement.Next);
            currentElement.Next = newElement;
        }

        /// <summary>
        /// Deletes element with highest priority
        /// </summary>
        /// <returns>Value of deleted element</returns>
        public TValue Dequeue()
        {
            if (Empty)
            {
                throw new EmptyQueueException();
            }
            size--;
            var result = head.Value;
            head = head.Next;
            return result;
        }
    }
}
