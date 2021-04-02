using System;

namespace ParseTree
{
    /// <summary>
    /// Class for an operand
    /// </summary>
    public class Number : INode
    {
        private double value;

        public Number(double newValue)
            => value = newValue;

        public void Print()
            => Console.Write($"{value} ");

        public double Count()
            => value;
    }
}
