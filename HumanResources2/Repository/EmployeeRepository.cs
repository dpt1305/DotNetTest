using Dapper;
using HumanResources2.Context;
using HumanResources2.Interfaces;
using HumanResources2.Model;

namespace HumanResources2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;
        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> Create(Employee employee)
        {


            string query = $"INSERT INTO Employees (EmployeeID, Name, Age, DepartureID) VALUES (\'{employee.EmployeeID}\', \'{employee.Name}\', '{employee.Age}', CONVERT(uniqueidentifier, \'{employee.DepartureID ?? null}\') );";
            using (var connection = _context.CreateConnection())
            {
                IEnumerable<Employee> employee1 = await connection.QueryAsync<Employee>(query);
                return employee1;
            }
            // throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> Delete(Guid id)
        {
            string query = $"DELETE FROM Employees WHERE EmployeeID = \'{id}\';";
            using (var connection = _context.CreateConnection())
            {
                IEnumerable<Employee> employees = await connection.QueryAsync<Employee>(query);
                return employees;
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> FindAll()
        {
            string query = $"SELECT EmployeeID, Name, Age, DepartureID FROM Employees;";
            using (var connection = _context.CreateConnection())
            {
                IEnumerable<Employee> employees = await connection.QueryAsync<Employee>(query);

                return employees;
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> FindOneById(Guid id)
        {
            string query = $"SELECT em.EmployeeID, em.Name, em.Age, em.DepartureID FROM Employees as em WHERE em.EmployeeID = \'{id}\'";
            using (var connection = _context.CreateConnection())
            {
                IEnumerable<Employee> employees = await connection.QueryAsync<Employee>(query);

                return employees;
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> Update(Employee entity)
        {
            string query = $"UPDATE Employees SET Name=\'{entity.Name}\', Age=\'{entity.Age}\', DepartureID=\'{entity.DepartureID}\' WHERE EmployeeID = \'{entity.EmployeeID}\';";
            using (var connection = _context.CreateConnection())
            {
                IEnumerable<Employee> employees = await connection.QueryAsync<Employee>(query);
                return employees;
            }
            throw new NotImplementedException();
        }
    }
}

