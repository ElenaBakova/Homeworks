using System;
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
        public bool IsCompleted { get; private set; }
        private ManualResetEvent lockResult = new(false);
        private object lockObject = new();

        public TResult Result 
        {
            get
            {
                lockResult.WaitOne();
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
                throw new AggregateException(e);
            }
            lock (lockObject)
            {
                function = null;
                IsCompleted = true;
                lockResult.Set();
            }
        }

        /*public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
        {

        }*/
    }
}
