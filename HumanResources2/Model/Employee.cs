using System;
namespace HumanResources2.Model
{
    public class Employee
    {
        public Guid? EmployeeID { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public Guid? DepartureID { get; set; }

        public Employee(Guid employeeID, string name, int age, Guid departureID)
        {
            EmployeeID = employeeID;
            Name = name;
            Age = age;
            DepartureID = departureID;
        }

        public Employee()
        {
        }
    }
}

