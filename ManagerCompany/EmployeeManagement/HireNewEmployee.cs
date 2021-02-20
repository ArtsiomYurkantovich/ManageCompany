using System;

namespace ManageCompany
{
    public class HireNewEmployee
    {
        public static void AddNewListEmployee()
        {
            Employee employee = new Employee();

            ManagmentApp.ShowMessage("Enter Id");
            employee.Id = InputVerificationID.EnterIdEmployee();

            while (Employee.EmployeeList.Exists(x => x.Id == employee.Id))
            {
                ManagmentApp.ShowMessage("Enter new ID");
                employee.Id = InputVerificationID.EnterIdEmployee();
            }

            ManagmentApp.ShowMessage("Enter FirstName");
            employee.FirstName = Console.ReadLine();

            ManagmentApp.ShowMessage("Enter SecondNAme");
            employee.SecondName = Console.ReadLine();

            RasePositionEmployee.ChangePosition(employee);

            Employee.EmployeeList.Add(new Employee(employee.Id, employee.FirstName, employee.SecondName, employee.Position));

            ShowEmployee.InformationEmployee(employee);
        }
    }
}
