using System;

namespace Calculator
{
    /// <summary>
    /// First-in-first-out container interface
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Pushes value into stack
        /// </summary>
        /// <param name="value">Pushed value</param>
        void Push(double value);

        /// <summary>
        /// Deletes top value from stack
        /// </summary>
        /// <returns>Top value from stack</returns>
        double Pop();

        bool Empty { get; }

        /// <summary>
        /// Deletes whole stack
        /// </summary>
        void ClearStack();
    }
}
