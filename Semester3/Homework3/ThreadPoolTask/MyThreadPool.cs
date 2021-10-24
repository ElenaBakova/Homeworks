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
        private ManualResetEvent tasksExecutionWait = new(false);
        private int executedThreadsCount = 0;
        private object lockObject = new();

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
                            if (!tasksQueue.IsEmpty)
                            {
                                newTaskWait.Set();
                            }
                        }
                    }
                    Interlocked.Increment(ref executedThreadsCount);
                    tasksExecutionWait.Set();
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
            if (cancellationTokenSource.IsCancellationRequested)
            {
                throw new InvalidOperationException("Thread pool is shutting down");
            }
            if (function == null)
            {
                throw new ArgumentNullException(nameof(function));
            }

            var task = new Task<TResult>(function, this);
            EnqueueTask(task.Start);
            return task;
        }

        /// <summary>
        /// Adds task to the queue
        /// </summary>
        public void EnqueueTask(Action action)
        {
            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            tasksQueue.Enqueue(action);
            newTaskWait.Set();
        }

        /// <summary>
        /// Shutting down all threads: previously submitted tasks are executed, but no new tasks will be accepted
        /// </summary>
        public void Shutdown()
        {
            lock (lockObject)
            {
                cancellationTokenSource.Cancel();
            }

            while (executedThreadsCount != threads.Length)
            {
                newTaskWait.Set();
                tasksExecutionWait.WaitOne();
            }
        }
    }
}
