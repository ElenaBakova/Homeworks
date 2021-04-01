using System;

namespace ParseTree
{
    class Division : Operation
    {
        char Operator { get; set; }
        public Division()
        {
            Operator = '/';
        }

        public override double Count()
            => RightChild.Count() == 0 ? throw new DivideByZeroException() : LeftChild.Count() / RightChild.Count();

        public override void Print()
        {
            Console.WriteLine(" ( ");
            LeftChild.Print();
            Console.WriteLine("/");
            RightChild.Print();
            Console.WriteLine(" ) ");
        }
    }
}
