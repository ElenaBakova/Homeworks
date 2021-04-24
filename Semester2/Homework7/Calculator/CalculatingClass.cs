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

        private int currentValue = 0;
        private Expression state = Expression.Empty;
        private double[] numbers = new double[2]{ 0, 0 };
        private char operation;

        public int Value { get => currentValue; }

        public void ClearEntry()
        {
            currentValue = 0;
            state = Expression.Empty;
            numbers[0] = 0;
            numbers[1] = 0;
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

        public void NewOperation(string button)
        {
            operation = button[0];

        }
    }
}
