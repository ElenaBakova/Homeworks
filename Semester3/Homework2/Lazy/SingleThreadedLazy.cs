using System;

namespace Lazy
{
    /// <summary>
    /// Single-threaded lazy realization
    /// </summary>
    class SingleThreadedLazy<T> : ILazy<T>
    {
        private Func<T> supplier;
        private T value;
        public bool IsValueCreated { get; private set; }

        /// <summary>
        /// Single-threaded lazy class constructor
        /// </summary>
        /// <param name="supplier">Counting function</param>
        public SingleThreadedLazy(Func<T> supplier)
            => this.supplier = supplier;

        public T Get()
        {
            if (!IsValueCreated)
            {
                IsValueCreated = true;
                value = supplier();
            }
            return value;
        }
    }
}
