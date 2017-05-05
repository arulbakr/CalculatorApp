using System.Collections.Generic;
using Media.Calc.Core;
using NUnit.Framework;

namespace Media.Calc.Test
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void TestAdd()
        {
            var invoker = new CommandInvoker();
            var result = new ResultReceiver();

            var numbers = new List<Number>
            {
                new Number {EnteredNumber = 1, IsCalculated = false},
                new Number {EnteredNumber = 2, IsCalculated = false},
                new Number {EnteredNumber = 3, IsCalculated = false}
            };

            invoker.IncludeOperations(new AddCommand(result, numbers));
            invoker.CalculatingOperations();

            Assert.AreEqual(6.0, result.Answer);
        }

        [Test]
        public void TestSub()
        {
            var invoker = new CommandInvoker();
            var result = new ResultReceiver();

            var numbers = new List<Number>
            {
                new Number {EnteredNumber = 1, IsCalculated = false},
                new Number {EnteredNumber = 2, IsCalculated = false}
            };

            invoker.IncludeOperations(new SubtractCommand(result, numbers));
            invoker.CalculatingOperations();

            Assert.AreEqual(-1.0, result.Answer);
        }

        [Test]
        public void TestMultiply()
        {
            var invoker = new CommandInvoker();
            var result = new ResultReceiver();

            var numbers = new List<Number>
            {
                new Number {EnteredNumber = 4, IsCalculated = false},
                new Number {EnteredNumber = 2, IsCalculated = false}
            };

            invoker.IncludeOperations(new MultiplyCommand(result, numbers));
            invoker.CalculatingOperations();

            Assert.AreEqual(8.0, result.Answer);
        }

        [Test]
        public void TestDivide()
        {
            var invoker = new CommandInvoker();
            var result = new ResultReceiver();

            var numbers = new List<Number>
            {
                new Number {EnteredNumber = 4, IsCalculated = false},
                new Number {EnteredNumber = 2, IsCalculated = false}
            };

            invoker.IncludeOperations(new DivideCommand(result, numbers));
            invoker.CalculatingOperations();

            Assert.AreEqual(2.0, result.Answer);
        }

        [Test]
        public void TestSquareRoot()
        {
            var invoker = new CommandInvoker();
            var result = new ResultReceiver();

            var number = new Number {EnteredNumber = 4, IsCalculated = false};

            invoker.IncludeOperations(new SquareRootCommand(result, number));
            invoker.CalculatingOperations();

            Assert.AreEqual(2.0, result.Answer);
        }

        [Test]
        public void TestPower()
        {
            var invoker = new CommandInvoker();
            var result = new ResultReceiver();

            var numbers = new List<Number>
            {
                new Number {EnteredNumber = 4, IsCalculated = false},
                new Number {EnteredNumber = 2, IsCalculated = false}
            };

            invoker.IncludeOperations(new PowerCommand(result, numbers));
            invoker.CalculatingOperations();

            Assert.AreEqual(16.0, result.Answer);
        }

        [Test]
        public void TestAddAndSub()
        {
            var invoker = new CommandInvoker();
            var result = new ResultReceiver();

            var addNumbers = new List<Number>
            {
                new Number {EnteredNumber = 1, IsCalculated = false},
                new Number {EnteredNumber = 2, IsCalculated = false}
            };
            var addCommand = new AddCommand(result, addNumbers);
            invoker.IncludeOperations(addCommand);
            invoker.CalculatingOperations();

            Assert.AreEqual(3.0, result.Answer);
            invoker.RemoveOperation(addCommand);


            var subNumbers = new List<Number>
            {
                new Number {EnteredNumber = 3, IsCalculated = false}
            };
            invoker.IncludeOperations(new SubtractCommand(result, subNumbers));
            invoker.CalculatingOperations();

            Assert.AreEqual(0.0, result.Answer);
            invoker.RemoveOperation(addCommand);
        }
    }
}