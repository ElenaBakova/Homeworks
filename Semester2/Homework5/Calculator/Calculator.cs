﻿using System;

namespace Calculator
{
    /// <summary>
    /// Calculator that evaluates expression in postfix notation
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Counts an expression
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <param name="stack">Stack which is used to count an expression</param>
        /// <returns>Pair of expression value and boolean. False if there was an error</returns>
        public static (double, bool) CountAnExpression(string expression, IStack stack)
        {
            string[] numbers = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < numbers.Length; i++)
            {
                bool isNumber = int.TryParse(numbers[i], out int number);
                if (isNumber)
                {
                    stack.Push(number);
                }
                else
                {
                    if (stack.Empty)
                    {
                        return (0, false);
                    }
                    double second = stack.Pop();
                    if (stack.Empty)
                    {
                        return (0, false);
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
                                stack.ClearStack();
                                return (0, false);
                            }
                            stack.Push(first / second);
                            break;
                        default:
                            stack.ClearStack();
                            return (0, false);
                    };
                }
            }
            double result = stack.Pop();
            return stack.Empty ? (result, true) : (0, false);
        }
    }
}
