using System;

namespace Calculator
{
    /// <summary>
    /// Calculator class
    /// </summary>
    public class CalculatingClass
    {
        private enum Expression
        {
            Empty,
            FirstNumber,
            OperationSign,
            SecondNumber
        }

        private double? currentValue = null;
        private Expression state = Expression.Empty;
        private double[] numbers = new double[2];
        private char? operation;

        public double? Value { get => currentValue; }

        /// <summary>
        /// Clears currentValue, both numbers and state
        /// </summary>
        public void ClearEntry()
        {
            currentValue = null;
            state = Expression.Empty;
            operation = null;
            numbers[0] = 0;
            numbers[1] = 0;
        }

        private void CountExpression(char operationSign)
        {
            switch (operationSign)
            {
                case '+':
                    numbers[0] += numbers[1];
                    break;
                case '-':
                    numbers[0] -= numbers[1];
                    break;
                case '*':
                    numbers[0] *= numbers[1];
                    break;
                case '/':
                    if (Math.Abs(numbers[1]) <= 1e-6)
                    {
                        throw new DivideByZeroException();
                    }
                    numbers[0] /= numbers[1];
                    break;
                default:
                    break;
            }
            currentValue = numbers[0];
        }

        /// <summary>
        /// Handles new number event
        /// </summary>
        /// <param name="button">Pressed button</param>
        public void NewNumber(string button)
        {
            if (double.TryParse(button, out double number))
            {
                switch (state)
                {
                    case Expression.Empty:
                        state = Expression.FirstNumber;
                        numbers[0] = number;
                        break;
                    case Expression.FirstNumber:
                        numbers[0] = numbers[0] * 10 + number;
                        break;
                    case Expression.OperationSign:
                        state = Expression.SecondNumber;
                        numbers[1] = number;
                        break;
                    case Expression.SecondNumber:
                        numbers[1] = numbers[1] * 10 + number;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Handles new operation event
        /// </summary>
        /// <param name="button">Pressed button</param>
        public void NewOperation(string button)
        {
            switch (state)
            {
                case Expression.Empty:
                    throw new MissingOperandException();
                case Expression.FirstNumber:
                    state = Expression.OperationSign;
                    break;
                case Expression.OperationSign:
                    throw new MissingOperandException();
                case Expression.SecondNumber:
                    CountExpression(operation ?? button[0]);
                    state = Expression.OperationSign;
                    break;
                default:
                    break;
            }
            operation = button[0];
        }
    }
}
