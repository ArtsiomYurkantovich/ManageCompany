using System.Collections.Generic;

namespace ManageCompany
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Position Position { get; set; }
        public float Salary { get; set; }
        public static List<Employee> EmployeeList = new List<Employee>();
        public Employee()
        {
        }

        public Employee(int id, string name, string surname, Position position)
        {
            Id = id;
            FirstName = name;
            SecondName = surname;
            Position = position;
        }

        public abstract void SendCV(string text);
    }
}
