namespace ParseTree
{
    /// <summary>
    /// Tree node interface
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Prints class value
        /// </summary>
        void Print();

        /// <summary>
        /// Counts expression
        /// </summary>
        /// <returns>Counted value</returns>
        double Count();
    }
}
