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
        /// <typeparam name="T"></typeparam>
        private class QueueElement<T>
        {
            public QueueElement(T value, int priority, QueueElement<T> next)
            {
                Value = value;
                Priority = priority;
                Next = next;
            }

            public T Value { get; set; }
            public int Priority { get; set; }
            public QueueElement<T> Next { get; set; }
        }

    }
}
