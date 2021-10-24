using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
        public IMyTask<TResult> AddTask<TResult>(Func<TResult> function)
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

        /// <summary>
        /// IMyTask instance
        /// </summary>
        /// <typeparam name="TResult">Task type</typeparam>
        private class Task<TResult> : IMyTask<TResult>
        {
            private Func<TResult> function;
            private TResult result;
            private Exception resultException = null;
            private ManualResetEvent lockResult = new(false);
            private object lockObject = new();
            private Queue<Action> continuationTasksQueue = new();
            private MyThreadPool pool;
            public bool IsCompleted { get; private set; }

            /// <summary>
            /// Result of the task function
            /// </summary>
            public TResult Result
            {
                get
                {
                    lockResult.WaitOne();
                    if (resultException != null)
                    {
                        throw new AggregateException(resultException);
                    }
                    return result;
                }
            }

            /// <summary>
            /// Creates new task
            /// </summary>
            public Task(Func<TResult> func, MyThreadPool pool)
            {
                function = func;
                this.pool = pool;
            }

            /// <summary>
            /// Starts counting the task result
            /// </summary>
            /// <returns>Task result</returns>
            public void Start()
            {
                try
                {
                    result = function();
                }
                catch (Exception e)
                {
                    resultException = e;
                }
                lock (lockObject)
                {
                    function = null;
                    IsCompleted = true;
                    lockResult.Set();
                }
                DoContinueWith();
            }

            public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
            {
                lock (lockObject)
                {
                    var task = new Task<TNewResult>(() => func(Result), pool);
                    continuationTasksQueue.Enqueue(task.Start);
                    if (IsCompleted)
                    {
                        DoContinueWith();
                    }
                    return task;
                }
            }

            private void DoContinueWith()
            {
                while (continuationTasksQueue.Count > 0)
                {
                    var action = continuationTasksQueue.Dequeue();
                    pool.EnqueueTask(action);
                }
            }
        }
    }
}
