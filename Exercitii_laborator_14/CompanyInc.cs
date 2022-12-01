using System;
using System.Collections.Generic;
using System.Linq;
using Exercitii_laborator_14.Exceptions;

namespace Exercitii_laborator_14
{
    class CompanyInc
    {
        private static CompanyInc instance;
        private static readonly object locker = new object();
        public static CompanyInc Instance {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new CompanyInc();
                        }
                    }
                }
                return instance;
            } 
        }

        private readonly List<Employee> companyEmployees = new List<Employee>();

        private CompanyInc() { }


        /// <summary>
        /// Add new people to company
        /// </summary>
        /// <param name="luckyNewEmployee">The LUCKIEST man alive</param>
        public void AddEmployee(Employee luckyNewEmployee)
        {
            lock (locker)
            {
                companyEmployees.ForEach(e =>
                {
                    if (e.ID == luckyNewEmployee.ID)
                    {
                        throw new EmployeeAlreadyExistsException();
                    }
                });
                companyEmployees.Add(luckyNewEmployee);
            }
        }


        /// <summary>
        /// Get rid of unwanted people from company
        /// </summary>
        /// <param name="luckyNewEmployee">The UNLUCKIEST man alive</param>
        public Employee RemoveEmployee(Guid employeeID)
        {
            lock(locker)
            {
                Employee employeeToRemove = companyEmployees.Find(e => e.ID == employeeID);

                if (employeeToRemove == null)
                {
                    throw new EmployeeNotExistingException();
                }

                companyEmployees.Remove(employeeToRemove);
                return employeeToRemove;
            }
        }


        /// <summary>
        /// Returns the well paid employee in the Company
        /// </summary>
        /// <param name="department"></param>
        /// <returns>The well paid employees</returns>
        public List<Employee> GetNoOfWellPaidEmployees(double minimumSalary)
        {
            lock (locker)
            {
                List<Employee> employees = companyEmployees.FindAll(e => e.Salary > minimumSalary);

                if (employees.Count == 0)
                {
                    throw new NoWellPaidEmployeesExistInCompanyException();
                }
                return employees;
            }
        }


        /// <summary>
        /// Returns the employees in the department
        /// </summary>
        /// <param name="department"></param>
        /// <returns>Department employees</returns>
        public List<Employee> GetEmployeesByDepartment(Departments department)
        {
            lock (locker)
            {
                List<Employee> employees = companyEmployees.FindAll(e => e.Department == department);

                if (employees.Count == 0)
                {
                    throw new NoEmployeesExistInDepartmentException();
                }
                return employees;
            }
        }


        /// <summary>
        /// Returns the well paid employee in the company
        /// </summary>
        /// <returns>The well paid employee</returns>
        public List<Employee> GetMaxSalary()
        {
            lock (locker)
            {
                if (companyEmployees.Count == 0)
                {
                    throw new NoEmployeesExistInCompanyException();
                }
                return GetBestPaidEmployee(companyEmployees);
            }
        }


        /// <summary>
        /// Returns the best paid employee in the department
        /// </summary>
        /// <param name="department"></param>
        /// <returns>The well paid employees</returns>
        public List<Employee> GetMaxSalary(Departments department)
        {
            lock (locker)
            {
                if (companyEmployees.Count == 0)
                {
                    throw new NoEmployeesExistInCompanyException();
                }

                List<Employee> departmentEmployees = companyEmployees.FindAll(e => e.Department == department);

                if (departmentEmployees.Count == 0)
                {
                    throw new NoEmployeesExistInDepartmentException();
                }
                return GetBestPaidEmployee(departmentEmployees);
            }
        }


        /// <summary>
        /// Returns the best paid employee in the departments
        /// </summary>
        /// <param name="department"></param>
        /// <returns>The well paid employees</returns>
        public List<Employee> GetMaxSalary(List<Departments> departaments)
        {
            lock (locker)
            {
                List<Employee> employees = new List<Employee>();

                departaments.ForEach(d => employees.AddRange(GetMaxSalary(d)));

                return employees;
            }
        }


        /// <summary>
        /// Returns the sum of all companyEmployees salaries
        /// </summary>
        /// <returns>Sum of salaries</returns>
        public double GetTotalCost()
        {
            lock (locker)
            {
                return companyEmployees.Sum(e => e.Salary);
            }
        }


        /// <summary>
        /// Returns the sum of salaries in a departement
        /// </summary>
        /// <returns>Sum of salaries in department</returns>
        public double GetCostForDepartment(Departments department)
        {
            lock (locker)
            {
                return GetEmployeesByDepartment(department).Sum(e => e.Salary);
            }
        }


        /// <summary>
        /// Increase employee salary
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="percent"></param>
        public void IncreaseSalary(Guid employeeID, double increasePercentage)
        {
            lock (locker)
            {
                Employee luckyEmployee = companyEmployees.Find(e => e.ID == employeeID);

                if (luckyEmployee == null)
                {
                    throw new EmployeeNotExistingException();
                }

                luckyEmployee.RaiseSalary(increasePercentage);
            }
        }


        /// <summary>
        /// Increase department company Employees salaries
        /// </summary>
        /// <param name="department"></param>
        /// <param name="increasePercentage"></param>
        public void IncreaseSalary(Departments department, double increasePercentage)
        {
            lock (locker)
            {
                List<Employee> luckyEmployees = companyEmployees.FindAll(e => e.Department == department);

                if (luckyEmployees.Count == 0)
                {
                    throw new NoEmployeesExistInDepartmentException();
                }

                luckyEmployees.ForEach(e => e.RaiseSalary(increasePercentage));
            }
        }


        /// <summary>
        /// Increase departments company Employees salaries
        /// </summary>
        /// <param name="departments">The list of departments to raise salaries</param>
        /// <param name="increasePercentage"></param>
        /// <exception cref="NoEmployeesExistInDepartmentException"></exception>
        public void IncreaseSalary(List<Departments> departments, double increasePercentage)
        {
            lock (locker)
            {
                departments.ForEach(d => IncreaseSalary(d, increasePercentage));
            }
        }


        /// <summary>
        /// Returns the best paid Employees in the company
        /// </summary>
        /// <param name="companyEmployees">The list of the best paid Employees in the company</param>
        /// <returns></returns>
        private List<Employee> GetBestPaidEmployee(List<Employee> companyEmployees)
        {
            lock (locker)
            {
                double bestSalary = companyEmployees.Max(e => e.Salary);

                return companyEmployees.FindAll(e => e.Salary == bestSalary);
            }
        }
    }
}
