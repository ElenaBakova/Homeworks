using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadPoolTask.Tests
{
    public class Tests
    {
        private MyThreadPool pool;
        private const int numberOfThreads = 5;
        private int count = 0;

        [SetUp]
        public void Setup()
            => pool = new(numberOfThreads);
        
        [TearDown]
        public void Teardown()
            => pool.Shutdown();

        [Test]
        public void MinimumRunningThreadsCount()
            => Assert.Less(numberOfThreads, Process.GetCurrentProcess().Threads.Count);
        
        [Test]
        public void NullFunctionShouldThrowException()
            => Assert.Throws<ArgumentNullException>(() => pool.AddTask<object>(null));

        private object Result<TResult>(IMyTask<TResult> task)
            => task.Result;
        
        [Test]
        public void ResultShouldThrowException()
        {
            var task = pool.AddTask<object>(() => throw new ArgumentOutOfRangeException());
            Assert.Throws<AggregateException>(() => Result(task));
        }
        
        [Test]
        public void ResultShouldNotChange()
        {
            var task = pool.AddTask(() => Interlocked.Increment(ref count));
            var taskResult = task.Result;
            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual(taskResult, task.Result);
            }
        }

        [Test]
        public void AfterShutdownCantAddTask()
        {
            var task1 = pool.AddTask(() => Interlocked.Increment(ref count));
            var task2 = pool.AddTask(() => "abacaba");
            pool.Shutdown();
            Assert.Throws<InvalidOperationException>(() => pool.AddTask(() => Interlocked.Increment(ref count)));
        }
       
        [Test]
        public void AfterShutdownCanGetResult()
        {
            var task1 = pool.AddTask(() => Interlocked.Increment(ref count));
            var task2 = pool.AddTask(() => "abacaba");
            pool.Shutdown();
            Assert.AreEqual("abacaba", task2.Result);
            Assert.AreEqual(1, task1.Result);
        }
        
        [Test]
        public void CantUseContinueWithAfterShutdown()
        {
            var task = pool.AddTask(() => 3 * 7);
            pool.Shutdown();
            Assert.Throws<InvalidOperationException>(() => task.ContinueWith(x => string.Concat(x, "twenty one")));
        }
        
        [Test]
        public void ContinueWithTest()
        {
            var stringA = "aba";
            var stringC = "caba";
            var stringD = "daba";
            var task1 = pool.AddTask(() => stringA);
            var task2 = task1.ContinueWith(x => x + stringC);
            var task3 = task1.ContinueWith(x => x + stringD);
            var task4 = task2.ContinueWith(x => x + stringD);
            Assert.AreEqual(task1.Result, stringA);
            Assert.AreEqual(task2.Result, stringA + stringC);
            Assert.AreEqual(task3.Result, stringA + stringD);
            Assert.AreEqual(task4.Result, stringA + stringC + stringD);
        }
    }
}