using NUnit.Framework;
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
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            //var math = new Math(); - commented because we have that in SetUp on the top of the class

            var result = _math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            //var math = new Math(); - commented because we have that in SetUp on the top of the class

            var result = _math.Max(1, 2);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
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
    }
}
