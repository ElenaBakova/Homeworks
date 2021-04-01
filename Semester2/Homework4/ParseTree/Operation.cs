namespace ParseTree
{
    abstract class Operation : INode
    {
        public INode LeftChild { get; set; }
        public INode RightChild { get; set; }

        abstract public void Print();

        abstract public double Count();
    }
}
