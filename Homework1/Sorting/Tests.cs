using System;

namespace Sorting
{
    class Tests
    {
        public static bool Test()
        {
            const int size = 10;
            int[] array = MakeArray(size);
            Program.Sort(array);
            bool result = true;
            for (int i = 1; i < size; i++)
            {
                result &= (array[i - 1] < array[i]);
            }
            return result;
        }

        private static int[] MakeArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                Random random = new Random();
                array[i] = random.Next();
            }
            return array;
        }
    }
}
