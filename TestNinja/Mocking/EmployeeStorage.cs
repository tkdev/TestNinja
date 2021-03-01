namespace TestNinja.Mocking
{
    public interface IEmployeeStorage
    {
        void DeleteEmployeeById(int id);
    }

    public class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeContext _employeeContext;

        public EmployeeStorage()
        {
            _employeeContext = new EmployeeContext();
        }

        public void DeleteEmployeeById(int id)
        {
            var employee = _employeeContext.Employees.Find(id);
            if (employee == null) return;

            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }
    }
}
