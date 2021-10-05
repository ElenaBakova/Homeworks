using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ThreadPoolTask
{
    /// <summary>
    /// Thread pool class
    /// </summary>
    public class MyThreadPool
    {
        private Thread[] threads;
        private object lockObject = new();
        private CancellationTokenSource source = new();
        private ConcurrentQueue<Action> tasksQueue = new();

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

            threads = new Thread[threadsCount];
            for (int i = 0; i < threadsCount; i++)
            {
               // threads[i] = new Thread(() => {
               //
               // });

               // threads[i].Start();
            }
        }

        /// <summary>
        /// Shutting down all threads: previously submitted tasks are executed, but no new tasks will be accepted
        /// </summary>
        public void Shutdown()
        {

        }

        /// <summary>
        /// Adds task to the thread queue
        /// </summary>
        /// <param name="action"></param>
        public void AddTask(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }

            tasksQueue.Enqueue(action);
        }
    }
}
