using System;
using System.Collections.Generic;
using Exercitii_laborator_14.Departments;

namespace Exercitii_laborator_14
{
    class CompanyInc
    {
        private readonly static CompanyInc _instance = new CompanyInc();
        public static CompanyInc Instance { get => _instance; }

        private readonly List<Employee> _companyEmployees = new List<Employee>();
        public List<Employee> CompanyEmployees { get => _companyEmployees; }

        private CompanyInc() { }


        /// <summary>
        /// Add new people to the company
        /// </summary>
        /// <param name="luckyNewEmployee">The LUCKIEST man alive</param>
        public void AddEmployee(Employee luckyNewEmployee) => _companyEmployees.Add(luckyNewEmployee);


        /// <summary>
        /// Get rid of unwanted people from the company
        /// </summary>
        /// <param name="luckyNewEmployee">The UNLUCKIEST man alive</param>
        public void RemoveEmployee(Guid employeeID)
        {
            _companyEmployees.RemoveAll(e =>
            {
                if (e.ID == employeeID)
                {
                    Console.WriteLine($"Finally!! We got rid of {e.Name} from {e.Department}");
                    return true;
                }
                return false;
            });
        }


        public List<Employee> GetNoOfWellPayedEmployees()
        {
            //
            return _companyEmployees;
            //
        }


        public List<Employee> GetEmployeesByDepartment(IDepartment searchedEmployeesDepartment)
        {
            // exceptions if no employee exists in departmentX
            return _companyEmployees.FindAll(e => e.Department == searchedEmployeesDepartment);
        }
    }
}
