using System;

namespace UniqueList
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UniqueList list = new UniqueList();
                list.Add(5, 0);
                list.Add(4, 1);
                list.Add(6, 0);
                list.Add(6, 0);
                list.Add(3, 2);
                list.Add(2, 3);
                list.Add(2, 3);
                list.Delete(10);
                list.Delete(5);
                list.Delete(3);
                list.Delete(2);
            }
            catch (AddingExistingValueException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (DeletingNonPresentElementException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
