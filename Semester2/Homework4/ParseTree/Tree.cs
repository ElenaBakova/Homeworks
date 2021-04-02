using System;

namespace ParseTree
{
    class Tree : INode
    {
        INode root;

        public void BuildTree(string[] expression)
        {
            int position = 0;
            root = CreateTree(expression, ref position);
        }

        private bool IsOperator(char symbol)
            => symbol == '+' || symbol == '-' || symbol == '/' || symbol == '*';

        private Operation OperatorSwitch(string symbol) =>
            symbol switch
            {
                "+" => new Addition(),
                "-" => new Subtraction(),
                "/" => new Division(),
                "*" => new Multiplication(),
                _=> throw new ArgumentException("Invalid expression"),
            };

        private INode CreateTree(string[] expression, ref int current)
        {
            if (current >= expression.Length)
            {
                return null;
            }

            bool isNumber = int.TryParse(expression[current], out int value);
            if (!isNumber && IsOperator(expression[current][0]))
            {
                var newNode = OperatorSwitch(expression[current]);
                current++;
                newNode.LeftChild = CreateTree(expression, ref current);
                newNode.RightChild = CreateTree(expression, ref current);
                return newNode;
            }
            if (isNumber)
            {
                current++;
                return new Number(value);
            }
            return null;
        }

        public void Print()
            => root.Print();

        public double Count()
            => root.Count();
    }
}
