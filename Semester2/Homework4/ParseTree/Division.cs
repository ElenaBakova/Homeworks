using System;

namespace ParseTree
{
    class Division : Operation
    {
        public char Operator { get; init; }

        public override double Count()
            => RightChild.Count() == 0 ? throw new DivideByZeroException() : LeftChild.Count() / RightChild.Count();

        public override void Print()
        {
            Console.WriteLine(" ( ");
            LeftChild.Print();
            Console.WriteLine(Operator);
            RightChild.Print();
            Console.WriteLine(" ) ");
        }
    }
}
