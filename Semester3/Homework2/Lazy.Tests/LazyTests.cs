using NUnit.Framework;
using System;

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
    }
}