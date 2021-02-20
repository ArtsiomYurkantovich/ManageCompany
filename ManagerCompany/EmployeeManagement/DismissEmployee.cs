using System.Linq;

namespace ManageCompany
{
    public class DismissEmployee
    {
        public static int RemoveFromList()
        {
            ManagmentApp.ShowErrorRed("Enter please ID employees that do you dismiss");
            int id = InputVerificationID.NoEmployeeWithId();

            var itemRemove = Employee.EmployeeList.SingleOrDefault(r => r.Id == id);

            if (itemRemove != null)
            {
                Employee.EmployeeList.Remove(itemRemove);
                ManagmentApp.ShowErrorRed($"Employee ID = {id} is removed!");
                ShowEmployee.InformationEmployee(itemRemove);
                return id;
            }

            else
            {
                return 0;
            }
        }
    }
}
