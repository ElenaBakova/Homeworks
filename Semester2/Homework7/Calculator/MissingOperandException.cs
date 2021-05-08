using System;
using System.Runtime.Serialization;

namespace Calculator
{
    [Serializable]
    public class MissingOperandException : ArgumentException
    {
        public MissingOperandException()
        {
        
        }

        public MissingOperandException(string message)
        : base(message)
        {
        
        }

        public MissingOperandException(string message, Exception inner)
        : base(message, inner)
        {
        
        }

        protected MissingOperandException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        
        }
    }
}
