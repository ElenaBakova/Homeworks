using System;

namespace ParseTree
{
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
