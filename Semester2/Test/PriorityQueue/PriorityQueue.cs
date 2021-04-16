using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    /// <summary>
    /// Priority queue class
    /// </summary>
    /// <typeparam name="TValue">Type of the value</typeparam>
    class PriorityQueue<TValue>
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
        /// Adds new element to the queue
        /// </summary>
        /// <param name="value">New element value</param>
        /// <param name="priority">Priority of new element</param>
        public void Enqueue(TValue value, int priority)
        {
            size++;
            if (Empty || head.Priority < priority)
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

        public TValue Dequeue()
        {

        }
    }
}
