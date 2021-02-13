using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter size of array");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter array");
            string read = Console.ReadLine();
            string[] numbers = read.Split(' ');
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(numbers[i]);
            }
            Sort(array);
            Console.Write("Sorted array: ");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }

        private static void Sort(int[] array)
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
