﻿using System;
using System.Threading;
using ThreadPoolTask;

namespace TemporaryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            MyThreadPool pool = new(2);
            var task1 = pool.AddTask(() => Interlocked.Increment(ref count));
            var task2 = pool.AddTask(() => "abacaba");
            Console.WriteLine(task2.Result);
            Console.WriteLine(task1.Result);
            var task3 = pool.AddTask(() => Interlocked.Increment(ref count));
            Console.WriteLine(task2.Result);
            var task4 = pool.AddTask(() => "yeeah");
            Console.WriteLine(task4.Result);
            Console.WriteLine(task3.Result);
            Console.WriteLine(task1.Result);
            var task5 = task3.ContinueWith(x => string.Concat(x.ToString(), "hh"));
            Console.WriteLine(task5.Result);
            var task6 = pool.AddTask(() => "ab");
            Console.WriteLine(task6.Result);
            pool.Shutdown();
        }
    }
}
