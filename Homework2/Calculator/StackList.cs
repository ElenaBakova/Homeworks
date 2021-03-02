namespace Calculator
{
    /// <summary>
    /// First-in-first-out container based on list
    /// </summary>
    public class StackList : IStack
    {
        private class StackElement
        {
            public double value;
            public StackElement next;
        }

        private StackElement head;

        public void Push(double value)
            => head = new StackElement()
            {
                value = value,
                next = head
            };

        public double Pop()
        {
            double topValue = head.value;
            head = head.next;
            return topValue;
        }

        public bool IsEmpty()
            => head == null;

        public void DeleteStack()
            => head = null;
    }
}
