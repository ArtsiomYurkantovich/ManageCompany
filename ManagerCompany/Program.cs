using SalesApp.EmployeeManagement;

namespace ManageCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeOfCompany.AddCurrentEmployee();
            ManagmentApp.RunApplication();
        }
    }
}
