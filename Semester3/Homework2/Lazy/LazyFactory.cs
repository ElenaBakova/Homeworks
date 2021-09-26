using System;

namespace Lazy
{
    /// <summary>
    /// Class for creating ILazy<T> objects
    /// </summary>
    public class LazyFactory
    {
        /// <summary>
        /// Creates single-threaded ILazy<T> realization
        /// </summary>
        /// <param name="supplier">Counting function</param>
        /// <returns>Single-threaded realization</returns>
        public static Lazy<T> CreateSingleThreadedLazy<T>(Func<T> supplier)
            => new SingleThreadedLazy<T>(supplier);

        /// <summary>
        /// Creates multi-threaded ILazy<T> realization
        /// </summary>
        /// <param name="supplier">Counting function</param>
        /// <returns>Multi-threaded realization</returns>
        public static Lazy<T> CreateMultiThreadedLazy<T>(Func<T> supplier)
            => new MultiThreadedLazy<T>(supplier);
    }
}
