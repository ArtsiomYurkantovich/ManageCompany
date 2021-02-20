namespace ManageCompany
{
    class EmployeeOfCompany
    {
        private static void AddListManager()
        {
            Employee.EmployeeList.Add(new Manager(2, "Lera", "Ivanova", Position.Manager));
            Employee.EmployeeList.Add(new Manager(3, "Esen", "Sidorova", Position.Manager));
        }

        private static void AddListExecutive()
        {

            Employee.EmployeeList.Add(new Executive(1, "Anton", "Popov", Position.Executive));
        }

        private static void AddListSalariedEmployee()
        {
            Employee.EmployeeList.Add(new SalariedEmployee(4, "Ivan", "Pupkin", Position.SalariedEmployee));
            Employee.EmployeeList.Add(new SalariedEmployee(5, "Dima", "Ivanov", Position.SalariedEmployee));
        }

        private static void AddListHourlyEmployee()
        {
            Employee.EmployeeList.Add(new HourlyEmployee(6, "Petr", "Sergeev", Position.HourlyEmployee));
            Employee.EmployeeList.Add(new HourlyEmployee(7, "Sergey", "Semenov", Position.HourlyEmployee));
        }

        public static void AddCurrentEmployee()
        {
            AddListExecutive();
            AddListHourlyEmployee();
            AddListSalariedEmployee();
            AddListManager();
        }
    }
}
