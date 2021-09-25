using System;

namespace Lazy
{
    /// <summary>
    /// Multi-threaded lazy realization
    /// </summary>
    class MultiThreadedLazy<T> : ILazy<T>
    {
        private Func<T> supplier;
        private T value;
        public bool IsValueCreated { get; private set; }

        /// <summary>
        /// Multi-threaded lazy class constructor
        /// </summary>
        /// <param name="supplier">Counting function</param>
        public MultiThreadedLazy(Func<T> supplier)
            => this.supplier = supplier;

        public T Get()
        {
            /*if (!IsValueCreated)
            {
            }
            IsValueCreated = true;
            value = supplier();*/
            return value;
        }
    }
}
