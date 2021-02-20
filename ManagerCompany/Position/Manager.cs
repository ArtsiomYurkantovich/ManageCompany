using System;

namespace ManageCompany
{
    class Manager : Employee
    {
        private static float bonus;
        public static float salaryManager;

        public Manager(int id, string name, string surname, Position position) : base(id, name, surname, position)
        { }

        public static float SalaryManager()
        {
            PaymentBonus();
            salaryManager = DataSalary.managerdRate + bonus;
            return salaryManager;
        }

        public static float PaymentBonus()
        {
            int amountOfSales;
            ManagmentApp.ShowMessage($"Enter please amount of sales in this month:");

            while (!int.TryParse(Console.ReadLine(), out amountOfSales))
            {
                ManagmentApp.ShowErrorRed("Please enter the correct amount of sales in this month.\n");
            }

            if (amountOfSales > 30 && amountOfSales <= 45)
            {
                bonus = DataSalary.managerdRate * 0.1F;
            }

            else if (amountOfSales > 45 && amountOfSales <= 60)
            {
                bonus = DataSalary.managerdRate * 0.2F;
            }

            else if (amountOfSales > 60)
            {
                bonus = DataSalary.managerdRate * 0.3F;
            }

            else
            {
                bonus = 0;
                ManagmentApp.ShowErrorRed("Next month you need to try to get the bonus.");
            }

            return bonus;
        }
    }
}
