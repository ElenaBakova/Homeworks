using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Tests.Test())
            {
                Console.WriteLine("Tests failed");
                Environment.Exit(1);
            }
            Console.WriteLine("Tests succeed");

            Console.WriteLine("Enter array");
            string read = Console.ReadLine();
            string[] numbers = read.Split(' ');
            int[] array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                array[i] = int.Parse(numbers[i]);
            }
            Sort(array);
            Console.Write("Sorted array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }

        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
