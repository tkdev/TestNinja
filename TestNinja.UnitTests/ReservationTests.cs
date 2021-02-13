//using Microsoft.VisualStudio.TestTools.UnitTesting; // We don't need this - we use NUnit 
using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    //[TestClass] // MS Test used [TestClass]
    [TestFixture] // NUnit uses [TestFixture] for test classes
    public class ReservationTests
    {
        /*
         * Test Naming convention:
         * 1. Method under test
         * 2. Scenario we are testing
         * 3. Expected behaviour
         * 
         * So it should look like: MethodUnderTest_Scenario_ExpectedBehaviour
         * example: CanBeCancelled_UserIsAdmin_ReturnsTrue
         * 
         */
        //[TestMethod] //MS Test uses [TestMethod]
        [Test] // NUnit uses [Test] for test methods
        public void CanBeCancelled_AdminCancelling_ReturnsTrue()
        {
            /*
             * In all tests we have 3 parts: 
             * 
             * Arrange (Initialise and prepare object(s) that we want to test)
             * 
             * Act (Act on object(s) - call a method which we are going to test)
             * 
             * Assert (verify that result from Act is correct / what you expect)
             */

            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            //Assert.IsTrue(result); //MS Test allows to write asserts only in this way
            //NUnit allows to write Asserts in additional, easier to read ways:
            Assert.That(result, Is.True); // We will be using this for now - it is easy to read
            // or
            //Assert.That(result == true);
            //and MS Test way is also valid in NUnit:
            //Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelled_AnotherUserNotAdminCancelling_ReturnsFalse()
        {
            //Arrange 
            var reservation = new Reservation();

            //Act 
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CanBeCancelled_SameUserNotAdminCancelling_ReturnsTrue()
        {
            //Arrange
            var user = new User { IsAdmin = false };
            var reservation = new Reservation();
            reservation.MadeBy = user;

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
