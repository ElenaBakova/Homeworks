using System;
using System.Runtime.Serialization;

namespace PriorityQueue
{
    /// <summary>
    /// Throws in attempt to delete from empty queue
    /// </summary>
    [Serializable]
    public class EmptyQueueException : InvalidOperationException
    {
        public EmptyQueueException()
        {

        }

        public EmptyQueueException(string message) 
        : base(message)
        {
                
        }

        public EmptyQueueException(string message, Exception inner) 
        : base(message, inner)
        {
        
        }

        protected EmptyQueueException(SerializationInfo info, StreamingContext context) 
        : base(info, context)
        {
        
        }
    }
}
