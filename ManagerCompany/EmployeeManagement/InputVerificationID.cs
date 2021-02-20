using System;

namespace ManageCompany
{
    public class InputVerificationID
    {
        public static int EnterIdEmployee()
        {
            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                ManagmentApp.ShowErrorRed("Enter correct plese ID employee.\n");
            }
            return id;
        }

        public static int NoEmployeeWithId()
        {
            int Id = EnterIdEmployee();

            while (!Employee.EmployeeList.Exists(x => x.Id == Id))
            {
                ManagmentApp.ShowErrorRed("There is no employee with this ID.");
                Id = EnterIdEmployee();
            }
            return Id;
        }
    }
}
