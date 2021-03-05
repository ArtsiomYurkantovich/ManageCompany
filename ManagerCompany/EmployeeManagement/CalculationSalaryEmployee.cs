using System.Linq;

namespace ManageCompany
{
    public class CalculationSalaryEmployee
    {
        public static void CalculationSalaryEmpl()
        {
            var manager = new ManagmentApp();

            manager.ShowMessage("Choise ID employees do you calculation salary");
            int id = InputVerificationID.NoEmployeeWithId();

            var employee = Employee.EmployeeList.SingleOrDefault(r => r.Id == id);

            if (employee.Position == Position.Executive)
            {
                employee.Salary = Executive.SalaryExecutive();
                ShowEmployee.InformationEmployee(employee);
            }

            else if (employee.Position == Position.HourlyEmployee)
            {
                employee.Salary = HourlyEmployee.SalaryHourlyEmployee();
                ShowEmployee.InformationEmployee(employee);
            }

            else if (employee.Position == Position.Manager)
            {
                employee.Salary = Manager.SalaryManager();
                ShowEmployee.InformationEmployee(employee);
            }

            else if (employee.Position == Position.SalariedEmployee)
            {
                employee.Salary = DataSalary.salariedRate;
                ShowEmployee.InformationEmployee(employee);
            }
        }
    }
}
