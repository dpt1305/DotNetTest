using System;
namespace HumanResources2.Model
{
    public class Employee
    {
        public string? EmployeeID { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? DepartureID { get; set; }

        public Employee(string employeeID, string name, int age, string departureID)
        {
            EmployeeID = employeeID;
            Name = name;
            Age = age;
            DepartureID = departureID;
        }

        public Employee(string employeeID, string name, int age)
        {
            EmployeeID = employeeID;
            Name = name;
            Age = age;
        }

        public Employee()
        {
        }
    }
}

