using System;
using System.Text;


namespace Exercitii_laborator_14
{
    class Employee
    {
        private readonly string name;
        private readonly Guid id;
        private readonly Departments department;
        private double salary;

        public string Name { get => name; }
        public Guid ID { get => id; }
        public Departments Department { get => department; }
        public double Salary { get => salary; }

        public Employee(string name, double baseSalary, Departments department)
        {
            this.name = name;
            id = Guid.NewGuid();
            this.department = department;
            salary = baseSalary;
        }


        /// <summary>
        /// Mareste salariul angajatului cu un anumit procent
        /// </summary>
        /// <param name="raisePercentage">Procentul cu care se va mari salariul</param>
        public void RaiseSalary(double raisePercentage) => salary += salary * raisePercentage / 100d;

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
