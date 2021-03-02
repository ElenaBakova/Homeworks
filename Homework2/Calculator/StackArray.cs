namespace Calculator
{
    /// <summary>
    /// First-in-first-out container based on array
    /// </summary>
    public class StackArray : IStack
    {
        private double[] stack;
        private int top = -1;

        public StackArray()
        {
            stack = new double[100];
        }

        public void Push(double value)
        {
            top++;
            stack[top] = value;
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
        {
            stack = null;
            top = -1;
        }
    }
}
