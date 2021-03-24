using System;

namespace UniqueList
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Add(5, 0);
            list.Add(4, 1);
            list.Add(6, 0);
            list.Add(3, 2);
            list.Add(2, 3);
            list.Delete(0);
            list.Delete(5);
            list.Delete(3);
            list.Delete(2);
        }
    }
}
