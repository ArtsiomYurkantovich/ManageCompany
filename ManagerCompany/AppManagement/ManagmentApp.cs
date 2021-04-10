using System;

namespace ManageCompany
{
    public class ManagmentApp
    {
        private bool RequestedExit;
        public void RunApplication()
        {
            while (!RequestedExit)
            {
                ShowCommands();
                WaitForCommand();
            }
        }

        private void WaitForCommand()
        {
            int command;

            while (!int.TryParse(Console.ReadLine(), out command))
            {
                ShowErrorRed($"Command doesn't exist\n");
            }

            ApplyCommand(command);
        }

        public void ApplyCommand(int command)
        {
            ManagmentEmployee manEmpl = new ManagmentEmployee();
            switch ((Menu)command)
            {
                case Menu.ShowCompany:
                    manEmpl.ShowDisplayEmployee();
                    break;
                case Menu.ShowIdPositionCompany:
                    manEmpl.ShowIdPositionCompany();
                    break;
                case Menu.AddEmployee:
                    manEmpl.AddNewListEmployee();
                    break;
                case Menu.DismissalEmployee:
                    manEmpl.RemoveFromList();
                    break;
                case Menu.RaseRateEmployee:
                    manEmpl.RasePosition();
                    break;
                case Menu.CalculateSalaryBonus:
                    manEmpl.CalculationSalaryEmpl();
                    break;
                case Menu.Clear:
                    Console.Clear();
                    break;
                case Menu.Exit:
                    RequestedExit = true;
                    break;
            }
        }

        public void ShowCommands()
        {
            ShowMessage("\nSELECT ONE OF THE COMMANDS!!!\n");
            ShowMessage(
                        $"1 - Current employees of the company.",
                        $"2 - Shows the id and positions of the current employees of the company.",
                        $"3 - Hire a new employee.",
                        $"4 - Dismiss an employee from the company.",
                        $"5 - Promotion of a company employee.",
                        $"6 - Calculation of the salary of the current employee",
                        $"7 - Clear display.",
                        $"8 - Exit the application.");
        }

        public static void ShowMessage(params string[] msgs)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var msg in msgs)
            {
                Console.WriteLine(msg);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowErrorRed(params string[] msgs)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var msg in msgs)
            {
                Console.WriteLine(msg);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
