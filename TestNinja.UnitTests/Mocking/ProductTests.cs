using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            var product = new Product { ListPrice = 100 };

            var result = product.GetPrice(new Customer { IsGold = true });

            Assert.That(result, Is.EqualTo(70));
        }

        //Example of the same test as above, but this time if we use Mock 
        //in this case we use Mock where it is not necessary.
        //In real life scenario Mocking every class will cause tests to be bigger and bulkier than they could be. 
        
        // Suggestion: Use Mock, but Mocking should be reserved for removing External resources

        // Exception: our Classes depend on each other and have complicated executions and calculations 
        //                   - that creates a huge amount of execution paths and test cases
        // in that case to simplify testing, Mocking is helpful - it allows to test each class independently and in isolation

        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount2()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(c => c.IsGold).Returns(true);

            var product = new Product { ListPrice = 100 };

            var result = product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(70));
        }
    }
}
