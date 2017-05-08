using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunctionalProgrammingDemo.Closure
{
    [TestClass]
    public class AddIntToList
    {
        [TestMethod]
        public void NonThreadSafe()
        {
            var dataList = new List<int>();
            int i = 0;
            Parallel.For(i, 9999, each => AddToList(dataList, ++i));
            Assert.AreEqual(9999, dataList.Count);
        }

        private void AddToList(List<int> currentList, int newLong)
        {
            currentList.Add(newLong);
        }

        [TestMethod]
        public void ThreadSafe()
        {
            var dataList = new List<int>();
            int i = 0;
            Parallel.For(i, 9999, each => dataList = AddToListSafe(dataList, i));
            //Assert.AreEqual(9999, dataList.Count);
        }

        private List<int> AddToListSafe(List<int> currentList, int newLong)
        {
            var immutableList = new List<int>(currentList);
            immutableList.Add(newLong);
            return immutableList;
        }
    }
}
