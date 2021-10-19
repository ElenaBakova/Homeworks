using System;
using System.Collections;
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
        private Queue continuationTasksQueue = new();
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
        public Task(Func<TResult> func)
            => function = func;

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

        public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func, MyThreadPool pool)
        {
            lock (lockObject)
            {
                var task = new Task<TNewResult>(() => func(Result));
                continuationTasksQueue.Enqueue(task);
                return pool.AddTask(() => func(Result));
            }
        }

        private void DoContinueWith()
        {

        }
    }
}
