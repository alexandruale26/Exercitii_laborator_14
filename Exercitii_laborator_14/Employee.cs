using System;
using System.Text;
using Exercitii_laborator_14.Departments;


namespace Exercitii_laborator_14
{
    class Employee
    {
        private readonly string _name;
        private readonly Guid _id;
        private readonly IDepartment _department;
        private double _salary;

        public string Name { get => _name; }
        public Guid ID { get => _id; }
        public IDepartment Department { get => _department; }
        public double Salary { get => _salary; }


        public Employee(string name, double baseSalary, IDepartment department)
        {
            _name = name;
            _id = Guid.NewGuid();
            _department = department;
            _salary = baseSalary;
        }


        /// <summary>
        /// Mareste salariul angajatului cu un anumit procent
        /// </summary>
        /// <param name="raisePercentage">Procentul cu care se va mari salariul</param>
        public void RaiseSalary(double raisePercentage) => _salary += _salary * raisePercentage / 100d;


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employee name:  {Name} ");
            sb.AppendLine($"Employee ID:  {ID}");
            sb.AppendLine($"Employee Salary:  {Salary} lei");
            sb.AppendLine($"Employee Department:  {Department}");

            return sb.ToString();
        }
    }
}
