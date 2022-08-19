using System;
namespace HumanResources2.Model
{
    public class Departure
    {
        public Guid DepartureID { get; set; }
        public string? Name { get; set; }

        public List<Employee> employees { get; set; } = new List<Employee>();
        public Departure(string name)
        {
            this.DepartureID = Guid.NewGuid();
            this.Name = name;
        }

        public Departure()
        {
        }
    }
}

