

namespace Exercitii_laborator_14.Departments
{
    class DevelopmentDepartment : IDepartment
    {
        private readonly static DevelopmentDepartment _instance = new DevelopmentDepartment();
        public static DevelopmentDepartment Instance { get => _instance; }


        private DevelopmentDepartment() { }


        public override string ToString() => "Development Department";
    }
}
