using System.Linq;
using System;

namespace ManageCompany
{
    public class ShowEmployee
    {
        public static void InformationEmployee(Employee employee)
        {
            ManagmentApp.ShowMessage(
                        $"Employee ID: {employee.Id}",
                        $"Name: {employee.FirstName}",
                        $"Surname: {employee.SecondName}",
                        $"Position: {employee.Position}",
                        $"Salary: {employee.Salary} $");
        }

        public static void ShowDisplayEmployee()
        {
            int i = 1;
            var sortedEmployee = from empl in Employee.EmployeeList
                                 orderby empl.Id
                                 select empl;

            foreach (Employee empl in sortedEmployee)
            {
                ManagmentApp.ShowErrorRed("********* Employee " + i + " *********");
                InformationEmployee(empl);
                i++;
            }
        }
        
        public static void ShowIdPositionCompany()
        {
            int i = 1;
            var sortedEmployee = from empl in Employee.EmployeeList
                                 orderby empl.Id
                                 select empl;

            foreach (Employee empl in sortedEmployee)
            {
                ManagmentApp.ShowErrorRed($"{empl.Id} --- {empl.Position} --- {empl.Salary}$");
            }
        }
    }
}