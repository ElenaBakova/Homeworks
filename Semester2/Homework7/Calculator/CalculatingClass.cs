namespace Calculator
{
    /// <summary>
    /// Calculator class
    /// </summary>
    class CalculatingClass
    {
        private enum Expression
        {
            Empty,
            FirstNumber,
            OperationSign,
            SecondNumber
        }

        private int currentValue = 0;
        private Expression state = Expression.Empty;
        private double[] numbers = new double[2]{ 0, 0 };
        private char operation;

        public void ClearEntry()
        {
            currentValue = 0;
            state = Expression.Empty;
        }

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
                        throw new MissingOperandException();
                    case Expression.OperationSign:
                        state = Expression.SecondNumber;
                        numbers[1] = number;
                        break;
                    case Expression.SecondNumber:
                        throw new MissingOperandException();
                    default:
                        break;
                }
            }
        }
    }
}
