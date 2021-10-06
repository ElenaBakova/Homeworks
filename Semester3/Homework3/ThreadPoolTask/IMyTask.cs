using System;

namespace ThreadPoolTask
{
    /// <summary>
    /// Task interface
    /// </summary>
    /// <typeparam name="TResult">Result type</typeparam>
    interface IMyTask<TResult>
    {
        /// <summary>
        /// True if task is completed
        /// </summary>
        public bool IsCompleted { get; }

        /// <summary>
        /// Task result
        /// </summary>
        public TResult Result { get; }

        /// <summary>
        /// Creates a continuation
        /// </summary>
        /// <param name="func">New function</param>
        /// <typeparam name="TNewResult">New result type</typeparam>
        /// <returns>New task</returns>
        //public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func);
    }
}
