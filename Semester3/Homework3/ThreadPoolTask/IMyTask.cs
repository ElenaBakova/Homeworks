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
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Task result
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// Creates a continuation
        /// </summary>
        /// <typeparam name="TNewResult">New result type</typeparam>
        public void ContinueWith<TNewResult>(Func<TResult, TNewResult> func);
    }
}
