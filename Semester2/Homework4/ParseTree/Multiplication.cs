using System;

namespace ParseTree
{
    /// <summary>
    /// Class for a multiplication operation
    /// </summary>
    class Multiplication : Operation
    {
        public override double Count()
            => LeftChild.Count() * RightChild.Count();

        public override void Print()
        {
            Console.Write("( * ");
            base.Print();
        }
    }
}
