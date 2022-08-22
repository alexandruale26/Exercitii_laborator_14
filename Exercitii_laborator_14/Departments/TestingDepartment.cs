

namespace Exercitii_laborator_14.Departments
{
    class TestingDepartment : IDepartment
    {
        private readonly static TestingDepartment _instance = new TestingDepartment();
        public static TestingDepartment Instance { get => _instance; }

        private readonly double _baseSalary = 4_000d;
        public double BaseSalary => _baseSalary;


        private TestingDepartment() { }


        public override string ToString() => "Testing Department";
    }
}
