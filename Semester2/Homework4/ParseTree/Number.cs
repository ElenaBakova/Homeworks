using System;

namespace ParseTree
{
    public class Number : INode
    {
        double value;

        public Number(double newValue)
            => value = newValue;

        public void Print()
            => Console.Write($"{value} ");

        public double Count()
            => value;
    }
}
