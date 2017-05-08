using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalProgrammingDemo.ImmutableData
{
    [TestClass]
    public class Tuples
    {
        [TestMethod]
        public void ImmutableTuples()
        {
            var myTuple1 = new Tuple<int, string>(100, "Name 100");
            var myTuple2 = myTuple1;
            Assert.AreSame(myTuple1, myTuple2);
        }
    }
}
