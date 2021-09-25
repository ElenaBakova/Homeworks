using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}