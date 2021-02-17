using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(15)]
        public void GetOutput_NumberDivisibleBy3And5_ReturnFizzBuzz(int a)
        {
            var result = FizzBuzz.GetOutput(a);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        [TestCase(3)]
        [TestCase(6)]
        public void GetOutput_NumberDivisibleBy3_ReturnFizz(int a)
        {
            var result = FizzBuzz.GetOutput(a);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void GetOutput_NumberDivisibleBy5_ReturnBuzz(int a)
        {
            var result = FizzBuzz.GetOutput(a);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        [TestCase(-2)]
        [TestCase(4)]
        public void GetOutput_NumberNotDivisableBy3Or5_ReturnPassedNumberAsAString(int a)
        {
            var result = FizzBuzz.GetOutput(a);

            Assert.That(result, Is.EqualTo(a.ToString()));
        }
    }
}
