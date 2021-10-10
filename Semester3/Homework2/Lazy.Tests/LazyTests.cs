using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Lazy.Tests
{
    /// <summary>
    /// Lazy class tests
    /// </summary>
    public class Tests
    {
        [Test]
        public void SupplierCannotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => LazyFactory.CreateSingleThreadedLazy<int>(null));
            Assert.Throws<ArgumentNullException>(() => LazyFactory.CreateMultiThreadedLazy<int>(null));
        }

        private static IEnumerable<TestCaseData> Lazies()
        {
            int countSingle = 0;
            int count = 0;
            yield return new TestCaseData(LazyFactory.CreateSingleThreadedLazy(() => ++countSingle));
            yield return new TestCaseData(LazyFactory.CreateMultiThreadedLazy(() => Interlocked.Increment(ref count)));
        }

        [TestCaseSource(nameof(Lazies))]
        public void GetShouldNotChangeValue<T>(ILazy<T> lazy)
        {
            var value = lazy.Get();
            Assert.AreEqual(value, 1);
            Assert.AreEqual(value, lazy.Get());
        }

        [Test]
        public void RaceConditionsCheck()
        {
            var count = 0;
            var lazy = LazyFactory.CreateMultiThreadedLazy(() => Interlocked.Increment(ref count));
            const int threadsCount = 100;
            var threads = new Thread[threadsCount];

            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(() => {
                    lazy.Get();
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            Assert.AreEqual(1, count);
        }
    }
}