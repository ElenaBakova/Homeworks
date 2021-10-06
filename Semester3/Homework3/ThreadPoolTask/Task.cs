using System;
using System.Threading;

namespace ThreadPoolTask
{
    public class Task<TResult> : IMyTask<TResult>
    {
        private Func<TResult> function;
        private TResult result;
        public bool IsCompleted { get; private set; }
        public TResult Result { get; }
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

            try
            {
                result = function();
            }
            catch (Exception e)
            {
                throw new AggregateException(e);
            }

            function = null;
            IsCompleted = true;
            lockResult.Set();
        }

        /*public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
        {

        }*/
    }
}
