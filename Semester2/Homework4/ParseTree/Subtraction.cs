using System;

namespace ParseTree
{
    class Subtraction : Operation
    {
        char Operator { get; set; }
        public Subtraction()
        {
            Operator = '-';
        }

        public override double Count()
            => LeftChild.Count() - RightChild.Count();

        public override void Print()
        {
            Console.WriteLine(" ( ");
            LeftChild.Print();
            Console.WriteLine("-");
            RightChild.Print();
            Console.WriteLine(" ) ");
        }
    }
}
