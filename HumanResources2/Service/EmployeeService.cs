using HumanResources2.Repository;

namespace HumanResources2.Service
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

    }
}
