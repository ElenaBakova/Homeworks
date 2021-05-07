using System;

namespace ParseTree
{
    /// <summary>
    /// Class for a division operation
    /// </summary>
    class Division : Operation
    {
        public override double Count()
            => Math.Abs(RightChild.Count()) <= 1e-6 ? throw new DivideByZeroException() : LeftChild.Count() / RightChild.Count();

        public override void Print()
        {
            Console.Write("( / ");
            base.Print();
        }
    }
}
