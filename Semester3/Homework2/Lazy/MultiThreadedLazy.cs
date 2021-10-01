using System;

namespace Lazy
{
    /// <summary>
    /// Multi-threaded lazy realization
    /// </summary>
    public class MultiThreadedLazy<T> : Lazy<T>
    {
        private object lockObject = new();

        /// <summary>
        /// Multi-threaded lazy class constructor
        /// </summary>
        /// <param name="supplier">Counting function</param>
        public MultiThreadedLazy(Func<T> supplier)
            :base(supplier)
        {
        }

        public override T Get()
        {
            if (isValueCreated)
            {
                return value;
            }
            lock (lockObject)
            {
                if (isValueCreated)
                {
                    return value;
                }
                value = supplier();
                isValueCreated = true;
                supplier = null;
                return value;
            }
        }
    }
}
