using System.Linq;
using System;

namespace ManageCompany
{
    public class ManagmentEmployee
    {
        private int ChoisePosition()
        {
            int choisePosition;

            while (!int.TryParse(Console.ReadLine(), out choisePosition))
            {
                ManagmentApp.ShowErrorRed("Enter correct plese number of position.\n");
            }

            return choisePosition;
        }

        private Position ChangePosition(Employee empl)
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

        public void RasePosition()
        {
            ManagmentApp.ShowMessage("Choise ID employees do you change position");

            int Id = NoEmployeeWithId();

            var employee = Employee.EmployeeList.SingleOrDefault(r => r.Id == Id);

            if (employee.Position == Position.Executive)
            {
                ManagmentApp.ShowErrorRed($"Employee position = {employee.Position}, employee ID = {employee.Id}");
                ManagmentApp.ShowErrorRed("There is no higher position in the company.");
                InformationEmployee(employee);
            }

            else if (employee.Position == Position.Manager)
            {
                ManagmentApp.ShowErrorRed($"Employee position = {employee.Position}, employee ID = {employee.Id}");
                PossibleRAiseManager(employee);
                InformationEmployee(employee);
            }

            else if (employee.Position == Position.SalariedEmployee)
            {
                ManagmentApp.ShowErrorRed($"Employee position = {employee.Position}, employee ID = {employee.Id}");
                PossibleRAiseSalariedEmpl(employee);
                InformationEmployee(employee);
            }

            else if (employee.Position == Position.HourlyEmployee)
            {
                ManagmentApp.ShowErrorRed($"Employee position = {employee.Position}, employee ID = {employee.Id}");
                PossibleRAisHeourlyEmpl(employee);
                InformationEmployee(employee);
            }
        }

        private Position PossibleRAiseManager(Employee employee)
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

        private Position PossibleRAiseSalariedEmpl(Employee employee)
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

        private Position PossibleRAisHeourlyEmpl(Employee employee)
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
        private int EnterIdEmployee()
        {
            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                ManagmentApp.ShowErrorRed("Enter correct plese ID employee.\n");
            }
            return id;
        }

        private int NoEmployeeWithId()
        {
            int Id = EnterIdEmployee();

            while (!Employee.EmployeeList.Exists(x => x.Id == Id))
            {
                ManagmentApp.ShowErrorRed("There is no employee with this ID.");
                Id = EnterIdEmployee();
            }
            return Id;
        }

        public void AddNewListEmployee()
        {
            Employee employee = new Employee();

            ManagmentApp.ShowMessage("Enter Id");
            employee.Id = EnterIdEmployee();

            while (Employee.EmployeeList.Exists(x => x.Id == employee.Id))
            {
                ManagmentApp.ShowMessage("Enter new ID");
                employee.Id = EnterIdEmployee();
            }

            ManagmentApp.ShowMessage("Enter FirstName");
            employee.FirstName = Console.ReadLine();

            ManagmentApp.ShowMessage("Enter SecondNAme");
            employee.SecondName = Console.ReadLine();

            ChangePosition(employee);

            Employee.EmployeeList.Add(new Employee(employee.Id, employee.FirstName, employee.SecondName, employee.Position));

            InformationEmployee(employee);
        }

        public int RemoveFromList()
        {
            ManagmentApp.ShowErrorRed("Enter please ID employees that do you dismiss");
            int id = NoEmployeeWithId();

            var itemRemove = Employee.EmployeeList.SingleOrDefault(r => r.Id == id);

            if (itemRemove != null)
            {
                Employee.EmployeeList.Remove(itemRemove);
                ManagmentApp.ShowErrorRed($"Employee ID = {id} is removed!");
                InformationEmployee(itemRemove);
                return id;
            }
            else
            {
                return 0;
            }
        }

        public void CalculationSalaryEmpl()
        {
            ManagmentApp.ShowMessage("Choise ID employees do you calculation salary");
            int id = NoEmployeeWithId();

            var employee = Employee.EmployeeList.SingleOrDefault(r => r.Id == id);

            if (employee.Position == Position.Executive)
            {
                Executive executive = new Executive();
                employee.Salary = executive.SalaryExecutive();
                InformationEmployee(employee);
            }

            else if (employee.Position == Position.HourlyEmployee)
            {
                HourlyEmployee hourlyEmployee = new HourlyEmployee();
                employee.Salary = hourlyEmployee.SalaryHourlyEmployee();
                InformationEmployee(employee);
            }

            else if (employee.Position == Position.Manager)
            {
                Manager manager = new Manager();
                employee.Salary = manager.SalaryManager();
                InformationEmployee(employee);
            }

            else if (employee.Position == Position.SalariedEmployee)
            {
                employee.Salary = DataSalary.salariedRate;
                InformationEmployee(employee);
            }
        }

        private void InformationEmployee(Employee employee)
        {
            ManagmentApp.ShowMessage(
                        $"Employee ID: {employee.Id}",
                        $"Name: {employee.FirstName}",
                        $"Surname: {employee.SecondName}",
                        $"Position: {employee.Position}",
                        $"Salary: {employee.Salary} $");
        }

        public void ShowDisplayEmployee()
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

        public void ShowIdPositionCompany()
        {
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