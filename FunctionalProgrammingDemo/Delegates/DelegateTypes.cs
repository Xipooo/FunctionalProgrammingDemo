using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace FunctionalProgrammingDemo.Delegates
{
    [TestClass]
    public class DelegateTypes
    {
        public delegate void ActionDelegate(string newItem);
        public delegate string FunctionDelegate();
        public delegate bool PredicateDelegate(string newItem);

        public void MyAction(string item) { Debug.WriteLine(item); }
        public string MyFunction() => "MyFunction was called.";

        [TestMethod]
        public void AssigningFunctionsToDelegates()
        {
            ActionDelegate actionDelegate = MyAction;
            FunctionDelegate functionDelegate = MyFunction;

            actionDelegate("MyAction was called");
            Debug.WriteLine(functionDelegate());
        }

        public Action<string> Action;
        public Func<string> Function;

        [TestMethod]
        public void ActionAndFuncDelegates()
        {
            Action = MyAction;
            Function = MyFunction;
            Action("Action was called.");
            Debug.WriteLine(MyFunction());
        }

        [TestMethod]
        public void Lambdas()
        {
            ActionDelegate newAction = delegate (string newItem) { Debug.WriteLine(newItem); };
            FunctionDelegate newFunction = delegate () { return "newFunction was called."; };
        }
    }
}
