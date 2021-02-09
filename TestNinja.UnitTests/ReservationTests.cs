using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
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
        [TestMethod]
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
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelled_AnotherUserNotAdminCancelling_ReturnsFalse()
        {
            //Arrange 
            var reservation = new Reservation();

            //Act 
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
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
