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

        [TestMethod]
        public void NoTupleValidation()
        {
            var baseballPlayer = new Tuple<int, string, string>(42, "Jackie Robinson", "Dodgers");
            var iceCream = new Tuple<int, string, string>(32, "Baskin Robbins", "Vanilla");

            baseballPlayer = iceCream;
        }
    }
}
