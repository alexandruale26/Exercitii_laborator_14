using System;
using System.Collections.Generic;
using Exercitii_laborator_14.Departments;


namespace Exercitii_laborator_14
{
    class Program
    {

        static void Main(string[] args)
        {
            Employee ana = new Employee("Ana", HumanResourcesDepartment.Instance);
            Employee mihai = new Employee("Mihai", HumanResourcesDepartment.Instance);
            Employee elena = new Employee("Elena", HumanResourcesDepartment.Instance);
            Employee dan = new Employee("Dan", LogisticsDepartment.Instance);



            CompanyInc.Instance.AddEmployee(ana);
            CompanyInc.Instance.AddEmployee(mihai);
            CompanyInc.Instance.AddEmployee(elena);
            CompanyInc.Instance.AddEmployee(dan);


            //CompanyInc.Instance.RemoveEmployee(ana.ID);
            //CompanyInc.Instance.RemoveEmployee(mihai.ID);


            List<Employee> tempxx =  CompanyInc.Instance.GetEmployeesByDepartment(LogisticsDepartment.Instance);

            tempxx.ForEach(e => Console.WriteLine(e));
        }
    }
}
