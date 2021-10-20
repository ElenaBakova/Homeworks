using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPoolTask
{
    /// <summary>
    /// IMyTask instance
    /// </summary>
    /// <typeparam name="TResult">Task type</typeparam>
    public class Task<TResult> : IMyTask<TResult>
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