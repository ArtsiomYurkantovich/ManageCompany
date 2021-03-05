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
            switch ((Menu)command)
            {
                case Menu.ShowCompany:
                    ShowEmployee.ShowDisplayEmployee();
                    break;
                case Menu.ShowIdPositionCompany:
                    ShowEmployee.ShowIdPositionCompany();
                    break;
                case Menu.AddEmployee:
                    HireNewEmployee.AddNewListEmployee();
                    break;
                case Menu.DismissalEmployee:
                    DismissEmployee.RemoveFromList();
                    break;
                case Menu.RaseRateEmployee:
                    RasePositionEmployee.RasePosition();
                    break;
                case Menu.CalculateSalaryBonus:
                    CalculationSalaryEmployee.CalculationSalaryEmpl();
                    break;
                case Menu.Clear:
                    ClearDisplay();
                    break;
                case Menu.Info:
                    ShowCommands();
                    break;
                case Menu.Exit:
                    RequestedExit = true;
                    break;
            }
        }

        private void ClearDisplay()
        {
            Console.Clear();
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
                        $"7 - Clear console content.",
                        $"8 - Show list of commands.",
                        $"9 - Exit the application.");
        }

        public void ShowMessage(params string[] msgs)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var msg in msgs)
            {
                Console.WriteLine(msg);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowErrorRed(params string[] msgs)
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
