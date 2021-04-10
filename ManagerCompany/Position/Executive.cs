using System;

namespace ManageCompany
{
    public class Executive : Employee
    {
        private static int experience;
        private static int manageOfNumberPeople;

        private static float raiseRate;

        public Executive()
        { }
        public Executive(int id, string name, string surname, Position position) : base(id, name, surname, position)
        { }

        public float SalaryExecutive()
        {
            ManagmentApp.ShowMessage("Please enter your experience as a executive:");
            EnterExperence();

            while (experience > 50)
            {
                ManagmentApp.ShowErrorRed("Enter please real experience");
                EnterExperence();
            }
            ManagmentApp.ShowMessage("Please enter the number of people you managed:");

            EnterManageNumberOfPeople();
            while (experience > 2200000)
            {
                ManagmentApp.ShowErrorRed("Enter please real the number of people you managed");
                EnterManageNumberOfPeople();
            }

            if (experience > 1 && experience <= 4 && manageOfNumberPeople > 5 && manageOfNumberPeople <= 50)
            {
                raiseRate = 17000;
            }

            else if (experience > 4 && manageOfNumberPeople > 50)
            {
                raiseRate = 20000;
            }

            else
            {
                raiseRate = DataSalary.executivesRate;
            }

            return raiseRate;
        }

        private void EnterExperence()
        {
            while (!int.TryParse(Console.ReadLine(), out experience))
            {

                ManagmentApp.ShowErrorRed("Please enter the correct your experience as a executive.\n");
            }
        }

        private void EnterManageNumberOfPeople()
        {
            while (!int.TryParse(Console.ReadLine(), out manageOfNumberPeople))
            {
                ManagmentApp.ShowErrorRed("Please enter the correct the number of people you managed.\n");
            }
        }
    }
}
