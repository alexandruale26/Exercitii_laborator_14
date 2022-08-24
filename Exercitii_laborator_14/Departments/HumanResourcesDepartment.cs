

namespace Exercitii_laborator_14.Departments
{
    class HumanResourcesDepartment : IDepartment
    {
        private readonly static HumanResourcesDepartment _instance = new HumanResourcesDepartment();
        public static HumanResourcesDepartment Instance { get => _instance; }


        private HumanResourcesDepartment() { }


        public override string ToString() => "Human Resources Department";
    }
}
