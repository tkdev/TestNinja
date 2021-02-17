using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedOutOfLimit_ThrowAnException(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            Assert.That(() => calculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(30, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(69, 0)]
        [TestCase(70, 1)]
        [TestCase(100, 7)]
        public void CalculateDemeritPoints_WhenCalled_ReturnPoints(int speed, int points)
        {
            var calculator = new DemeritPointsCalculator();

            var result = calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(points));
        }
    }
}
