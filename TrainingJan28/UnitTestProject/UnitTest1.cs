using ConsoleApp1;
using NUnit.Framework;
using System;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestAddMethodWithValidArguments()
        {
            //3 A's of Testing -> Arrange, Act , Assert
            //Arrange - the objects required for performing the test
            Calculator calc = new ConsoleApp1.Calculator();
            int inputArg1 = 10, inputArg2 = 20;
            int expectedValue = inputArg1 + inputArg2;
            int actualValue = 0;

            //Act = perform the action
            actualValue = calc.Add(inputArg1, inputArg2);

            //Assert = the outputs are correct
            Assert.AreEqual(expectedValue, actualValue);

        }

        [Test]
        public void TestDivideMethodWithNegativeOrZeroDenominator()
        {
            Calculator calc = new Calculator();
            int inputArg1 = 0, inputArg2 = 0;

            //Act & Assert
            TestDelegate action = () => calc.Divide(inputArg1, inputArg2);
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void TestArraysOperations()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, };
            Assert.That(arr, Has.Length.EqualTo(6));
            Assert.That(arr, Is.Not.Empty);
            Assert.That(arr, Has.Exactly(1).Items.EqualTo(4));
        }
        [Test]
        public void TestClassInformation()
        {
            Calculator calc = new Calculator();
            Assert.That(calc, Has.Property("Item"));
        }

    }
}
