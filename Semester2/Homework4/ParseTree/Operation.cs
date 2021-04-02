using System;

namespace ParseTree
{
    abstract class Operation : INode
    {
        public INode LeftChild { get; set; }
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
