using SalesApp.EmployeeManagement;

namespace ManageCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeOfCompany.AddCurrentEmployee();
            ManagmentApp.RunApplication();



            var compMan = new CompanyManager();

            compMan.Hire(new Executive { });
            compMan.Hire(new Executive { });



            if()
        }
    }
}
