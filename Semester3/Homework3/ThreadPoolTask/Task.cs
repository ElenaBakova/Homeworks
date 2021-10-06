using System;
using System.Threading;

namespace ThreadPoolTask
{
    public class Task<TResult> : IMyTask<TResult>
    {
        private Func<TResult> function;
        public bool IsCompleted { get; }
        public TResult Result { get; private set; }
        private ManualResetEvent lockResult = new(false);

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
            lockResult.WaitOne();
            Result = function();
            function = null;
            lockResult.Set();
        }

        /*public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
        {

        }*/
    }
}
