class StackList : IStack
{
    private class StackElement
    {
        public int value;
        public StackElement next;
    }

    private StackElement head;

    public void Push(int value)
        => head = new StackElement() 
        {
            value = value,
            next = head 
        };

    public void Pop()
        => head = head.next;

    public bool IsEmpty()
        => head == null;

    public void DeleteStack()
        => head = null;
}
