using System;

namespace ParseTree
{
    class Multiplication : Operation
    {
        public char Operator { get; init; }

        public override double Count()
            => LeftChild.Count() * RightChild.Count();

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
