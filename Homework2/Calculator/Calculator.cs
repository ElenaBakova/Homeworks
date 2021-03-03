using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Calculator
    {
        public enum StackVariation
        {
            ArrayStack,
            ListStack
        }

        public static (double, bool) CountAnExpression(string expression, StackVariation variation)
        {
            string[] numbers = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IStack stack;
            switch (variation)
            {
                case StackVariation.ArrayStack:
                    stack = new StackArray();
                    break;
                case StackVariation.ListStack:
                    stack = new StackList();
                    break;
                default:
                    return (0, false);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                int number;
                bool isNumber = int.TryParse(numbers[i], out number);
                if (isNumber)
                {
                    stack.Push(number);
                }
                else
                {
                    if (stack.IsEmpty())
                    {
                        continue;
                    }
                    double second = stack.Pop();
                    if (stack.IsEmpty())
                    {
                        stack.Push(second);
                        continue;
                    }
                    double first = stack.Pop();
                    switch (numbers[i])
                    {
                        case "+":
                            stack.Push(first + second);
                            break;
                        case "-":
                            stack.Push(first - second);
                            break;
                        case "*":
                            stack.Push(first * second);
                            break;
                        case "/":
                            if (Math.Abs(second - 0) < 1e-6)
                            {
                                stack.DeleteStack();
                                return (0, false);
                            }
                            stack.Push(first / second);
                            break;
                        default:
                            stack.DeleteStack();
                            return (0, false);
                    };
                }
            }
            double result = stack.Pop();
            return stack.IsEmpty() ? (result, true) : (0, false);
        }
    }
}
