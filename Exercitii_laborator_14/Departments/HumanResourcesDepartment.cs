

namespace Exercitii_laborator_14.Departments
{
    class HumanResourcesDepartment : IDepartment
    {
        private readonly static HumanResourcesDepartment _instance = new HumanResourcesDepartment();
        public static HumanResourcesDepartment Instance { get => _instance; }

        private readonly double _baseSalary = 7_000d;
        public double BaseSalary => _baseSalary;


        private HumanResourcesDepartment() { }


        public override string ToString() => "Human Resources Department";
    }
}
