using System;
using System.Linq;

namespace ManageCompany
{
    public class RasePositionEmployee
    {
        public static int ChoisePosition()
        {
            int choisePosition;

            while (!int.TryParse(Console.ReadLine(), out choisePosition))
            {
                ManagmentApp.ShowErrorRed("Enter correct plese number of position.\n");
            }

            return choisePosition;
        }

        public static Position ChangePosition(Employee empl)
        {
            ManagmentApp.ShowMessage("Choise position: 1 - Executive, 2 - HourlyEmployee, 3 - Manager, 4 - Salaried employee");

            int choisePosition = ChoisePosition();

            switch (choisePosition)
            {
                case 1:
                    empl.Position = Position.Executive;
                    empl.Salary = DataSalary.executivesRate;
                    break;
                case 2:
                    empl.Position = Position.HourlyEmployee;
                    empl.Salary = DataSalary.hourlyRate;
                    break;
                case 3:
                    empl.Position = Position.Manager;
                    empl.Salary = DataSalary.managerdRate;

                    break;
                case 4:
                    empl.Position = Position.SalariedEmployee;
                    empl.Salary = DataSalary.salariedRate;
                    break;
                default:
                    ManagmentApp.ShowErrorRed($"Choise correct position number.\n");
                    ChangePosition(empl);
                    break;
            }

            return empl.Position;
        }

        public static void RasePosition()
        {
            ManagmentApp.ShowMessage("Choise ID employees do you change position");

            int Id = InputVerificationID.NoEmployeeWithId();

            var employee = Employee.EmployeeList.SingleOrDefault(r => r.Id == Id);

            if (employee.Position == Position.Executive)
            {
                ManagmentApp.ShowErrorRed($"Employee position = {employee.Position}, employee ID = {employee.Id}");
                ManagmentApp.ShowErrorRed("There is no higher position in the company.");
                ShowEmployee.InformationEmployee(employee);
            }

            else if (employee.Position == Position.Manager)
            {
                ManagmentApp.ShowErrorRed($"Employee position = {employee.Position}, employee ID = {employee.Id}");
                PossibleRAiseManager(employee);
                ShowEmployee.InformationEmployee(employee);
            }

            else if (employee.Position == Position.SalariedEmployee)
            {
                ManagmentApp.ShowErrorRed($"Employee position = {employee.Position}, employee ID = {employee.Id}");
                PossibleRAiseSalariedEmpl(employee);
                ShowEmployee.InformationEmployee(employee);
            }

            else if (employee.Position == Position.HourlyEmployee)
            {
                ManagmentApp.ShowErrorRed($"Employee position = {employee.Position}, employee ID = {employee.Id}");
                PossibleRAisHeourlyEmpl(employee);
                ShowEmployee.InformationEmployee(employee);
            }
        }

        public static Position PossibleRAiseManager(Employee employee)
        {
            ManagmentApp.ShowMessage("Choise position: 1 - Executive ");

            int choisePosition = ChoisePosition();
            switch (choisePosition)
            {
                case 1:
                    employee.Position = Position.Executive;
                    employee.Salary = DataSalary.executivesRate;
                    break;
                default:
                    ManagmentApp.ShowErrorRed($"Choise correct position number.\n");
                    PossibleRAiseManager(employee);
                    break;
            }

            return employee.Position;
        }

        public static Position PossibleRAiseSalariedEmpl(Employee employee)
        {
            ManagmentApp.ShowMessage("Choise position: 1 - Executive, 2 - Manager.");

            int choisePosition = ChoisePosition();

            switch (choisePosition)
            {
                case 1:
                    employee.Position = Position.Executive;
                    employee.Salary = DataSalary.executivesRate;
                    break;
                case 2:
                    employee.Position = Position.Manager;
                    employee.Salary = DataSalary.managerdRate;
                    break;
                default:
                    ManagmentApp.ShowErrorRed($"Choise correct position number.\n");
                    PossibleRAiseSalariedEmpl(employee);
                    break;
            }

            return employee.Position;
        }

        public static Position PossibleRAisHeourlyEmpl(Employee employee)
        {
            ManagmentApp.ShowMessage("Choise position: 1 - Executive, 2 - Manager, 3 - Salaried employee");

            int choisePosition = ChoisePosition();

            switch (choisePosition)
            {
                case 1:
                    employee.Position = Position.Executive;
                    employee.Salary = DataSalary.executivesRate;
                    break;
                case 2:
                    employee.Position = Position.Manager;
                    employee.Salary = DataSalary.managerdRate;
                    break;
                case 3:
                    employee.Position = Position.SalariedEmployee;
                    employee.Salary = DataSalary.salariedRate;
                    break;
                default:
                    ManagmentApp.ShowErrorRed($"Choise correct position number.\n");
                    PossibleRAisHeourlyEmpl(employee);
                    break;
            }

            return employee.Position;
        }
    }
}
