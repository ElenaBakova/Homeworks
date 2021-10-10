using System;
using System.Threading;

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
            if (Volatile.Read(ref isValueCreated))
            {
                return value;
            }
            lock (lockObject)
            {
                if (Volatile.Read(ref isValueCreated))
                {
                    return value;
                }
                value = supplier();
                Volatile.Write(ref isValueCreated, true);
                supplier = null;
                return value;
            }
        }
    }
}
