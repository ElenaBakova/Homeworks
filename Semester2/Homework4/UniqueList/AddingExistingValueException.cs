using System;

namespace UniqueList
{
    /// <summary>
    /// Adding value that already presented in the list
    /// </summary>
    public class AddingExistingValueException : Exception
    {
        public AddingExistingValueException()
        {
        }

        public AddingExistingValueException(string message) 
            : base(message)
        {
        }

        public AddingExistingValueException(string message, Exception inner) 
            : base(message, inner)
        {
        }

        protected AddingExistingValueException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}
