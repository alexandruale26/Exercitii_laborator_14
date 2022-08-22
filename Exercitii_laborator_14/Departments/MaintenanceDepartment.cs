

namespace Exercitii_laborator_14.Departments
{
    class MaintenanceDepartment : IDepartment
    {
        private readonly static MaintenanceDepartment _instance = new MaintenanceDepartment();
        public static MaintenanceDepartment Instance { get => _instance; }

        private readonly double _baseSalary = 6_000d;
        public double BaseSalary => _baseSalary;


        private MaintenanceDepartment() { }


        public override string ToString() => "Maintenance Department";
    }
}
