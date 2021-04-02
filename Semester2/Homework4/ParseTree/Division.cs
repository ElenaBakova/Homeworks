using System;

namespace ParseTree
{
    class Division : Operation
    {
        public override double Count()
            => RightChild.Count() == 0 ? throw new DivideByZeroException() : LeftChild.Count() / RightChild.Count();

        public override void Print()
        {
            Console.Write("( / ");
            base.Print();
        }
    }
}
