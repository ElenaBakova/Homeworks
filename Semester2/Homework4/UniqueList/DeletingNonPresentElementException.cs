using System;

namespace UniqueList
{
    /// <summary>
    /// Deleting element that is not in the list
    /// </summary>
    public class DeletingNonPresentElementException : ArgumentOutOfRangeException
    {
        public DeletingNonPresentElementException() { }

        public DeletingNonPresentElementException(string message)
            : base(message) { }

        public DeletingNonPresentElementException(string message, Exception inner)
            : base(message, inner) { }

        protected DeletingNonPresentElementException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) 
            : base(info, context) { }
    }
}
