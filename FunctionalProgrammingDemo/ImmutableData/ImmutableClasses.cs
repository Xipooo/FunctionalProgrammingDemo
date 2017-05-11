using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunctionalProgrammingDemo.ImmutableData
{
    public class MutableClass
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }

    [TestClass]
    public class MutableClasses
    {
        [TestMethod]
        public void TestMutableClass()
        {
            var mutClass1 = new MutableClass()
            {
                Id = 100,
                Name = "Name 100"
            };
            var mutClass2 = mutClass1;

            mutClass2.ChangeName("Name 200");

            Assert.AreEqual("Name 200", mutClass1.Name);
        }

        [TestMethod]
        public void NotThreadSafe()
        {
            var mutableClass = new MutableClass();

            Parallel.For(1, 999999,
                i => mutableClass.ChangeName(i % 2 == 0 ? "Foo" : "Bar"));

            Assert.AreEqual("Bar", mutableClass.Name);
        }
    }


    public class ImmutableClass
    {
        private readonly int _id;
        private readonly string _name;
        public int Id
        {
            get { return _id; }
        }
        public string Name
        {
            get { return _name; }
        }

        public ImmutableClass(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public ImmutableClass ChangeName(string newName)
        {
            return new ImmutableClass(this.Id, newName);
        }
    }

    [TestClass]
    public class ImmutableClasses
    {
        [TestMethod]
        public void TestImmutableClass()
        {
            var immutClass1 = new ImmutableClass(100, "Name 100");
            var immutClass2 = immutClass1;
            var immutClass3 = immutClass2.ChangeName("Name 200");

            Assert.AreEqual("Name 100", immutClass1.Name);
            Assert.AreEqual("Name 200", immutClass3.Name);
        }

    }

    public class AutoImmutableClass
    {
        public int Id { get; }
        public string Name { get; }

        public ImmutableClass ChangeName(string newName) => new ImmutableClass(this.Id, newName);
    }

    [TestClass]
    public class ImmutableLists
    {

        [TestMethod]
        public void ThreadSafeLists()
        {
            var immutableClassList = new ThreadSafeList<MutableClass>();
            Parallel.For(1, 9999,
                i => immutableClassList = immutableClassList.Add(new MutableClass { Id = i, Name = "Name " + i.ToString() }));

        }
    }
}
