using System;
using System.Threading;

namespace ThreadPoolTask
{
    /// <summary>
    /// Thread pool class
    /// </summary>
    class MyThreadPool
    {
        private readonly int threadsCount;
        private Thread[] threads;

        /// <summary>
        /// Thread pool constructor
        /// </summary>
        /// <param name="threadsCount">Number of threads</param>
        public MyThreadPool(int threadsCount)
        {
            if (threadsCount < 1)
            {
                throw new ArgumentOutOfRangeException("Number of threads can't be zero or less");
            }
            this.threadsCount = threadsCount;
            for (int i = 0; i < threadsCount; i++)
            {
               // threads[i] = new Thread();
            }
        }

        /// <summary>
        /// Shutting down all threads: previously submitted tasks are executed, but no new tasks will be accepted
        /// </summary>
        public void Shutdown()
        {

        }
    }
}
