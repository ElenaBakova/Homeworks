using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lazy.Tests
{
    public class Tests
    {
        [Test]
        public void SupplierCannotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => LazyFactory.CreateSingleThreadedLazy<int>(null));
            Assert.Throws<ArgumentNullException>(() => LazyFactory.CreateMultiThreadedLazy<int>(null));
        }

        private static object[] testData = new[]
        {
            2,
            10,
            "aabacaba",
            "bbaa" as object
        };

        private static IEnumerable<TestCaseData> Lazies
            => testData.SelectMany(data => new TestCaseData[]
               {
                   new TestCaseData(LazyFactory.CreateSingleThreadedLazy(() => data)),
                   new TestCaseData(LazyFactory.CreateMultiThreadedLazy(() => data))
               });

        [TestCaseSource(nameof(Lazies))]
        public void GetShouldNotChangeValue<T>(ILazy<T> lazy)
        {
            var value = lazy.Get();
            Assert.AreEqual(value, lazy.Get());
        }

        [Test]
        public void RaceConditionsCheck()
        {
            var count = 0;
            var lazy = LazyFactory.CreateSingleThreadedLazy(() => Interlocked.Increment(ref count));
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