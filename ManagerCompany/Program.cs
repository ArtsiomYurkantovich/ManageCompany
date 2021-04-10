namespace ManageCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeOfCompany.AddCurrentEmployee();
            ManagmentApp manApp = new ManagmentApp();
            manApp.RunApplication();
        }
    }
}
