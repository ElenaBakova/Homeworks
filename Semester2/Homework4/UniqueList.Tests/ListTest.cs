using NUnit.Framework;
using System.Collections.Generic;

namespace UniqueList.Tests
{
    [TestFixture]
    public class ListTest
    {
        [TestCaseSource(nameof(Lists))]
        public void AfterAddingShouldNotBeEmpty(List list)
        {
            list.Add(2, 0);
            Assert.IsFalse(list.Empty);
        }

        [TestCaseSource(nameof(Lists))]
        public void ValueShouldBeReplacedByNewOne(List list)
        {
            list.Add(2, 0);
            bool result = list.IsContain(2).Item1;
            list.ChangeElement(5, 0);
            result &= !list.IsContain(2).Item1 && list.IsContain(5).Item1;
            Assert.IsTrue(result);
        }

        private bool CheckPresent(List list, int start, int finish)
        {
            bool result = true;
            for (int i = start; i <= finish; i++)
            {
                result &= list.IsContain(i).Item1;
            }
            return result;
        }

        [TestCaseSource(nameof(Lists))]
        public void AddToTheList(List list)
        {
            list.Add(1, 0);
            list.Add(2, 1);
            list.Add(0, 0);
            list.Add(3, 3);
            Assert.IsTrue(CheckPresent(list, 0, 3));
        }

        [TestCaseSource(nameof(Lists))]
        public void ListSizeShouldBeIncreasedAfterAdd(List list)
        {
            list.Add(1, 0);
            list.Add(2, 1);
            Assert.AreEqual(list.Size, 2);
        }

        [TestCaseSource(nameof(Lists))]
        public void ListSizeShouldBeDecreasedAfterDelete(List list)
        {
            list.Add(1, 0);
            list.Add(2, 1);
            list.Add(3, 2);
            list.Delete(1);
            Assert.AreEqual(list.Size, 2);
        }

        private static IEnumerable<TestCaseData> Lists
            => new TestCaseData[]
                {
                    new TestCaseData(new List()),
                    new TestCaseData(new UniqueList())
                };
    }
}
