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
        private CancellationTokenSource cancellationTokenSource = new();
        private ConcurrentQueue<Action> tasksQueue = new();
        private ManualResetEvent newTaskWait = new(false);

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
                threads[i] = new Thread(() =>
                {
                    while (!cancellationTokenSource.IsCancellationRequested || !tasksQueue.IsEmpty)
                    {
                        if (tasksQueue.TryDequeue(out Action action))
                        {
                            action();
                        }
                        else
                        {
                            newTaskWait.WaitOne();
                            if(!tasksQueue.IsEmpty)
                            {
                                newTaskWait.Set();
                            }
                        }
                    }
                });

                threads[i].Start();
            }
        }

        /// <summary>
        /// Adds task to the thread queue
        /// </summary>
        /// <param name="function">Task function</param>
        public Task<TResult> AddTask<TResult>(Func<TResult> function)
        {
            if (function == null)
            {
                throw new ArgumentNullException();
            }

            var task = new Task<TResult>(function);
            tasksQueue.Enqueue(task.Start);
            newTaskWait.Set();
            return task;
        }

        /// <summary>
        /// Shutting down all threads: previously submitted tasks are executed, but no new tasks will be accepted
        /// </summary>
        public void Shutdown()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
