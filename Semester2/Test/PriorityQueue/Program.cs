using System;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> queue = new();
            queue.Enqueue(5, 1);
            queue.Enqueue(6, 0);
            queue.Enqueue(7, 4);
            queue.Enqueue(1, 1);
            queue.Enqueue(7, 5);
            Console.WriteLine(queue.Dequeue());
        }
    }
}
