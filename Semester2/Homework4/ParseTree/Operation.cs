using System;

namespace ParseTree
{
    /// <summary>
    /// Class for an operation
    /// </summary>
    abstract class Operation : INode
    {
        /// <summary>
        /// Left subtree
        /// </summary>
        public INode LeftChild { get; set; }

        /// <summary>
        /// Right subtree
        /// </summary>
        public INode RightChild { get; set; }

        public virtual void Print()
        {
            LeftChild.Print();
            RightChild.Print();
            Console.Write(") ");
        }

        abstract public double Count();
    }
}
