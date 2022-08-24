

namespace Exercitii_laborator_14.Departments
{
    class TestingDepartment : IDepartment
    {
        private readonly static TestingDepartment _instance = new TestingDepartment();
        public static TestingDepartment Instance { get => _instance; }


        private TestingDepartment() { }


        public override string ToString() => "Testing Department";
    }
}
