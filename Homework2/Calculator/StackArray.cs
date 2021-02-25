namespace Calculator
{
    class StackArray : IStack
    {
        private double[] stack;
        private int top = -1;

        public StackArray()
        {
            stack = new double[100];
        }

        public void Push(double value)
        {
            stack[top] = value;
            top++;
        }

        public double Pop()
        {
            double topValue = stack[top];
            top--;
            return topValue;
        }

        public bool IsEmpty()
            => top < 0;

        public void DeleteStack()
            => stack = null;
    }
}
