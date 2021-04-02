using System;

namespace ParseTree
{
    /// <summary>
    /// Sum of left and right subtree
    /// </summary>
    class Addition : Operation
    {
        public override double Count()
            => LeftChild.Count() + RightChild.Count();

        public override void Print()
        {
            Console.Write("( + ");
            base.Print();
        }
    }
}
