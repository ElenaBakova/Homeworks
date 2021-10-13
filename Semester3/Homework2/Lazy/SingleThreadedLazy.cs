using System;

namespace Lazy
{
    /// <summary>
    /// Single-threaded lazy realization
    /// </summary>
    public class SingleThreadedLazy<T> : Lazy<T>
    {
        /// <summary>
        /// Single-threaded lazy class constructor
        /// </summary>
        /// <param name="supplier">Counting function</param>
        public SingleThreadedLazy(Func<T> supplier)
            :base(supplier)
        {
        }

        public override T Get()
        {
            if (!isValueCreated)
            {
                isValueCreated = true;
                value = supplier();
                supplier = null;
            }
            return value;
        }
    }
}
