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
        /// Counts expression in the current subtree
        /// </summary>
        /// <returns>Counted value</returns>
        double Count();
    }
}
