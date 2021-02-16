using NUnit.Framework;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        private Math _math;

        /*
         * [SetUp] - run before each and every test in this class
         * [TearDown] - run after each and every test has finished running - usually used with Integration test 
         *              for example to clean up the database
         */

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //var math = new Math(); //instead of repeating this in each test we will use "SetUp" from NUnit

            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [Ignore("Because I test this in \"Max_WhenCalled_ReturnTheGraterArgument\" test as a test case")]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            //var math = new Math(); - commented because we have that in SetUp on the top of the class

            var result = _math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        [Ignore("Because I test this in \"Max_WhenCalled_ReturnTheGraterArgument\" test as a test case")]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            //var math = new Math(); - commented because we have that in SetUp on the top of the class

            var result = _math.Max(1, 2);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        [Ignore("Because I test this in \"Max_WhenCalled_ReturnTheGraterArgument\" test as a test case")]
        public void Max_BothArgumentsAreEqual_ReturnTheSecondArgument()
        {
            //var math = new Math(); - commented because we have that in SetUp on the top of the class

            var result = _math.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));
        }

        /* 
         * Or instead of three above tests we can do that all in one test but with three test cases 
         * [TestCase(2, 1, 2)] etc
         */

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGraterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            //Assert.That(result, Is.Not.Empty); //Very general assertion

            //Assert.That(result.Count(), Is.EqualTo(3)); // Also a general assertion

            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));
            //that can be done in one assertion:
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            //if we need to check if elements in collection are ordered, we can use:
            //Assert.That(result, Is.Ordered);

            //If collection has unique elements
            //Assert.That(result, Is.Unique);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void GetOddNumbers_LimitIsEqualOrLowerThanZero_ReturnEmptyCollection(int a)
        {
            var result = _math.GetOddNumbers(a);

            Assert.That(result, Is.Empty); 

            Assert.That(result.Count(), Is.EqualTo(0));
        }
    }
}
