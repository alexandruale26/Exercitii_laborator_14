

namespace Exercitii_laborator_14.Departments
{
    class LogisticsDepartment : IDepartment
    {
        private readonly static LogisticsDepartment _instance = new LogisticsDepartment();
        public static LogisticsDepartment Instance { get => _instance; }

        private readonly double _baseSalary = 5_000d;
        public double BaseSalary => _baseSalary;


        private LogisticsDepartment() { }


        public override string ToString() => "Logistics Department";
    }
}
