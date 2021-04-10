using System;

namespace ManageCompany
{
    public class HourlyEmployee : Employee
    {
        private int hWorked;
        private float salaryHourlyEmployee;
        public HourlyEmployee() { }
        public HourlyEmployee(int id, string name, string surname, Position position) : base(id, name, surname, position)
        { }

        public float SalaryHourlyEmployee()
        {
            EnterHourWorked();

            while (hWorked > 600)
            {
                ManagmentApp.ShowErrorRed("Maximum you could work 600 hours per month.");
                EnterHourWorked();
            }

            salaryHourlyEmployee = hWorked * DataSalary.hourlyRate;
            return salaryHourlyEmployee;
        }

        private void EnterHourWorked()
        {
            ManagmentApp.ShowMessage("Enter how many hours worked per month: ");
            while (!int.TryParse(Console.ReadLine(), out hWorked))
            {
                ManagmentApp.ShowErrorRed("Please enter the correct number of hours worked per month\n");
            }
        }
    }
}
