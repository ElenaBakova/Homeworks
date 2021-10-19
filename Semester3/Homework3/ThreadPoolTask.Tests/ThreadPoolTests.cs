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
        {
            pool = new(numberOfThreads);
        }
        
        [TearDown]
        public void Teardown()
        {
            pool.Shutdown();
        }

        [Test]
        public void MinimumRunningThreadsCount()
            => Assert.Less(numberOfThreads, Process.GetCurrentProcess().Threads.Count);
        
        [Test]
        public void ResultShouldNotChange()
        {
            var task= pool.AddTask(() => Interlocked.Increment(ref count));
            var taskResult = task.Result;
            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual(taskResult, task.Result);
            }
        }

        private object Result<TResult>(Task<TResult> task)
            => task.Result;

        [Test]
        public void AddTaskShouldNotThrowException()
        {
            var task= pool.AddTask<object>(() => throw new ArgumentOutOfRangeException());
            Assert.Throws<ArgumentOutOfRangeException>(() => Result(task));
        }
        
        [Test]
        public void NullFunctionShouldThrowException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => pool.AddTask<object>(null));
    }
}