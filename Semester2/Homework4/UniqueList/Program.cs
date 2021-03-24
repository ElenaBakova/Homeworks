using System;

namespace UniqueList
{
    class Program
    {
        static void Main(string[] args)
        {
            UniqueList list = new UniqueList();
            list.Add(5, 0);
            list.Add(4, 1);
            list.Add(6, 0);
            try
            {
                list.Add(6, 0);
            }
            catch (AddingExistingValueException ex)
            {
                Console.WriteLine($"{ex.Message}---\n");
            }
            list.Add(3, 2);
            list.Add(2, 3);
            list.Add(2, 3);
            try
            {
                list.Delete(10);
            }
            catch (DeletingNonPresentElementException ex)
            {
                Console.WriteLine(ex.Message);
            }
            list.Delete(5);
            list.Delete(3);
            list.Delete(2);
        }
    }
}
