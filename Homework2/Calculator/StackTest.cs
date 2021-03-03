namespace Calculator
{
    public class StackTest
    {
        public static bool PushTest(IStack stack)
        {
            stack.Push(1);
            return !stack.Empty;
        }

        public static bool EmptyStackIsEmptyShouldBeTrue(IStack stack)
        {
            return stack.Empty;
        }

        public static bool PopAfterPushWillReturnLastPushedValue(IStack stack)
        {
            stack.Push(55);
            stack.Push(-1.23);
            return -1.23 == stack.Pop();
        }

        public static bool DeletedValueShouldBeRplacedByNew(IStack stack)
        {
            stack.Push(5.2);
            stack.Pop();
            stack.Push(9.633);
            return 9.633 == stack.Pop();
        }
    }
}
