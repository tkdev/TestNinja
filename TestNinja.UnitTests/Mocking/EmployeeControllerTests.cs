using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        Mock<IEmployeeStorage> _employeeStorage { get; set; }

        EmployeeController _employeeController;

        [SetUp]
        public void Setup()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeStorage.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
        {
            _employeeController.DeleteEmployee(1);

            _employeeStorage.Verify(s => s.DeleteEmployeeById(1));
        }


    }
}
