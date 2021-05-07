using System;

namespace ParseTree
{
    /// <summary>
    /// Subtraction between left and right subtree
    /// </summary>
    class Subtraction : Operation
    {
        public override double Count()
            => LeftChild.Count() - RightChild.Count();

        public override void Print()
        {
            Console.Write("( - ");
            base.Print();
        }
    }
}
