using System;

namespace Lazy
{
    /// <summary>
    /// Multi-threaded lazy realization
    /// </summary>
    public class MultiThreadedLazy<T> : ILazy<T>
    {
        private Func<T> supplier;
        private T value;
        public bool IsValueCreated { get; private set; }
        private object lockObject = new();

        /// <summary>
        /// Multi-threaded lazy class constructor
        /// </summary>
        /// <param name="supplier">Counting function</param>
        public MultiThreadedLazy(Func<T> supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException();
            }
            this.supplier = supplier;
        }

        public T Get()
        {
            if (IsValueCreated)
            {
                return value;
            }
            lock (lockObject)
            {
                IsValueCreated = true;
                value = supplier();
                return value;
            }
        }
    }
}
