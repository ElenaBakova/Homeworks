using System;
using System.Runtime.Serialization;

namespace Routers
{
    /// <summary>
    /// Throws when graph is not connected
    /// </summary>
    [Serializable]
    public class UnconnectedGraphException : Exception
    {
        public UnconnectedGraphException() { }

        public UnconnectedGraphException(string message)
            : base(message) { }

        public UnconnectedGraphException(string message, Exception inner)
            : base(message, inner) { }

        protected UnconnectedGraphException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
