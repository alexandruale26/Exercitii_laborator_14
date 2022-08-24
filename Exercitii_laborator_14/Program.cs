using System;
using System.Collections.Generic;
using Exercitii_laborator_14.Departments;
using Exercitii_laborator_14.Exceptions;

namespace Exercitii_laborator_14
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Exercise
            /*
               Scrieti un sistem de gestiune a angajatilor.

                Angajatul va fi caracterizat de
                    • Nume
                    • Id :Guid
                    • Salary : double
                    • Department
                    • ToString – returneaza intr-o maniera prietenoasa toate informatiile despre angajat

                Departamentele pot fi
                    • Development
                    • Testing
                    • HumanResources
                    • Maintenance
                    • Logistics

                Sistemul de gestiune va fi unic la nivel de aplicatie si va fi modelat de o clasa care va avea urmatoarele :
                    • AddEmployee
                        o Adauga un angajat dat ca parametru
                    • RemoveEmployee
                        o Sterge un angajat in functie de ID-ul acestuia
                    • GetNoOfWellPayedEmployees
                        o Metoda va primi ca parametru o valoare numerica si va returna o lista cu toti angajatii cu salariul mai mare decat valoarea numerica oferita ca parametru
                    • GetEmployeesByDepartment
                        o Va primi ca parametru un departament si va returna o lista cu toti angajatii din acel departament
                    • GetMaxSalary
                        o O metoda fara parametri, care va returna angajatii cu cel mai mare salariu la nivel de companie
                    • GetMaxSalary
                        o Metoda va primi ca parametru un departament si va returna angajatii cu cel mai mare salariu din departamentul oferit ca parametru.
                    • GetTotalCost
                        o Metoda va returna o valoare numerica reprezentand suma tuturor salariilor din companie
                    • GetCostForDepartment
                        o Metoda va returna o valoare numerica reprezentand suma tuturor salariilor din departamentul oferit ca parametru
                    • IncreaseSalary
                        o Metoda va primi doi parametri, ID-ul angajatului si un procent si va mari salariul angajatului cu procentul dat ca parametru
                    • IncreaseSalary
                        o Metoda va primi doi parametri, un departament si un procent si va mari salariile tuturor angajatilor din acel departament cu procentul dat ca parametru

                Instantiati clasele, adaugati angajati, accesati metodele, afisati rezultatele. Folositi expresii lambda, functiile clasei List<T>: ForEach, FindAll, Count.
                     NU folositi instructiunea foreach:

                Suplimentar 2

                Sistemul de gestiune va fi unic la nivel de aplicatie si modelat de o clasa care va avea urmatoarele :
                 • GetMaxSalary
                    o Metoda va primi ca parametru o lista de departamente si va returna angajatii cu cel mai mare salariu din departamentele oferite ca parametru.
                 • IncreaseSalary
                    o Metoda va primi doi parametri, o lista de departamente si un procent si va mari salariile tuturor angajatilor din departamentele specificate cu procentul dat ca parametru
                 • GetMaxSalaryByDepartment
                    o Metoda va primi ca parametru o lista de departamente si va returna pentru fiecare departament, angajatii cu cel mai mare salariu.

                Aruncati exceptiile necesare.
            */
            #endregion

            #region Employees
            Employee ana = new Employee("Ana", 5_100d, HumanResourcesDepartment.Instance);
            Employee mihai = new Employee("Mihai", 7_000d, HumanResourcesDepartment.Instance);
            Employee elena = new Employee("Elena", 6_800d, MaintenanceDepartment.Instance);
            Employee dan = new Employee("Dan", 4_650d, TestingDepartment.Instance);
            Employee irina = new Employee("Irina", 3_500d, TestingDepartment.Instance);
            Employee tomita = new Employee("Tomita", 6_150d, MaintenanceDepartment.Instance);
            Employee gicu = new Employee("Gicu", 5_700d, DevelopmentDepartment.Instance);
            Employee anca = new Employee("Anca", 5_700d, DevelopmentDepartment.Instance);
            Employee filip = new Employee("Filip", 4_970d, TestingDepartment.Instance);
            Employee dorel = new Employee("Dorel", 4_970d, TestingDepartment.Instance);
            Employee mirela = new Employee("Mirela", 4_230d, TestingDepartment.Instance);
            Employee gabriela = new Employee("Gabriela", 4_970d, MaintenanceDepartment.Instance);
            #endregion

            #region Adding employees
            TryToAddEmployee(ana);
            TryToAddEmployee(mihai);
            TryToAddEmployee(elena);
            TryToAddEmployee(dan);
            TryToAddEmployee(irina);
            TryToAddEmployee(tomita);
            TryToAddEmployee(gicu);
            TryToAddEmployee(anca);
            TryToAddEmployee(filip);
            TryToAddEmployee(dorel);
            TryToAddEmployee(mirela);
            TryToAddEmployee(gabriela);
            Console.WriteLine();
            #endregion

            TryToAddEmployee(elena);
            TryToAddEmployee(anca);
            Console.WriteLine();


            TryToRemoveLazyEmployee(mihai.ID);
            TryToRemoveLazyEmployee(mihai.ID);
            Console.WriteLine();


            Console.WriteLine("These might be the best paid employees");
            TryGetNoOfWellPayedEmployees(6_000d);
            Console.WriteLine();


            TryGetEmployeesByDepartment(HumanResourcesDepartment.Instance);
            TryGetEmployeesByDepartment(LogisticsDepartment.Instance);
            Console.WriteLine();


            Console.WriteLine($"The Company is spending monthly {CompanyInc.Instance.GetTotalCost():N0} lei on salaries");
            TryToGetCostForDepartment(TestingDepartment.Instance);
            TryToGetCostForDepartment(HumanResourcesDepartment.Instance);
            TryToGetCostForDepartment(LogisticsDepartment.Instance);
            Console.WriteLine();


            TryIncreasingSalary(mihai.ID, 10d);
            TryIncreasingSalary(irina.ID, 15d);
            TryIncreasingSalary(irina.ID, 11.6d);
            Console.WriteLine();


            TryIncreasingSalary(TestingDepartment.Instance, 12.5d);
            TryIncreasingSalary(DevelopmentDepartment.Instance, 16.4d);
            TryIncreasingSalary(LogisticsDepartment.Instance, 13.7d);
            Console.WriteLine();


            List<IDepartment> listOfDepartments = new List<IDepartment>
            {   HumanResourcesDepartment.Instance, 
                DevelopmentDepartment.Instance, 
                LogisticsDepartment.Instance 
            };

            TryIncreasingSalary(listOfDepartments, 7.5d);
            Console.WriteLine();


            TryGetMaxSalary();
            Console.WriteLine();

            TryGetMaxSalary(LogisticsDepartment.Instance);
            Console.WriteLine();
            TryGetMaxSalary(TestingDepartment.Instance);
            Console.WriteLine();

            TryGetMaxSalary(listOfDepartments);
            Console.WriteLine();

            // GetMaxSalaryByDepartment is already included in "TryGetMaxSalary(List<IDepartment> departments)"
        }

        #region Methods
        static void TryToAddEmployee(Employee newEmployee)
        {
            try
            {
                CompanyInc.Instance.AddEmployee(newEmployee);
                Console.WriteLine($"Employee {newEmployee.Name} with ID: {newEmployee.ID} added");
            }
            catch (EmployeeAlreadyExistsException e)
            {
                Console.WriteLine(e.Message, newEmployee.Name, newEmployee.ID);
            }
        }

        static void TryToRemoveLazyEmployee(Guid employeeID)
        {
            try
            {
                CompanyInc.Instance.RemoveEmployee(employeeID);
                Console.WriteLine($"Employee with ID: {employeeID} removed");
            }
            catch (EmployeeNotExistingException e)
            {
                Console.WriteLine(e.Message, employeeID);
            }
        }

        static void TryGetNoOfWellPayedEmployees(double minimumSalary)
        {
            try
            {
                CompanyInc.Instance.GetNoOfWellPayedEmployees(minimumSalary).ForEach(e => Console.WriteLine(e));
            }
            catch (NoWellPaidEmployeesExistInCompanyException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        static void TryGetEmployeesByDepartment(IDepartment department)
        {
            try
            {
                CompanyInc.Instance.GetEmployeesByDepartment(department).ForEach(e => Console.WriteLine(e));
            }
            catch (NoEmployeesExistInDepartmentException e)
            {
                Console.WriteLine(e.Message, department);
            }
        }

        static void TryGetMaxSalary()
        {
            try
            {
                List<Employee> bestPaidEmployee = CompanyInc.Instance.GetMaxSalary();

                Console.WriteLine("Best paid employees in company are:");
                bestPaidEmployee.ForEach(e => Console.WriteLine($"{e.Name} with ID: {e.ID} with a salary of {e.Salary}"));
            }
            catch (NoEmployeesExistInCompanyException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void TryGetMaxSalary(IDepartment department)
        {
            try
            {
                List<Employee> bestPaidEmployee = CompanyInc.Instance.GetMaxSalary(department);

                Console.WriteLine($"Best paid employees in {department}");
                bestPaidEmployee.ForEach(e => Console.WriteLine($"{e.Name} with ID: {e.ID} with a salary of {e.Salary}"));
            }
            catch (NoEmployeesExistInCompanyException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NoEmployeesExistInDepartmentException e)
            {
                Console.WriteLine(e.Message, department);
            }
        }

        static void TryGetMaxSalary(List<IDepartment> departments)
        {
            departments.ForEach(d => TryGetMaxSalary(d));
        }

        static void TryToGetCostForDepartment(IDepartment department)
        {

            try
            {
                double salaries = CompanyInc.Instance.GetCostForDepartment(department);

                Console.WriteLine($"The {department} is spending monthly {salaries:N0} lei on salaries");

            }
            catch (NoEmployeesExistInDepartmentException e)
            {
                Console.WriteLine(e.Message, department);
            }

        }

        static void TryIncreasingSalary(Guid employeeID, double increasePercentage)
        {
            try
            {
                CompanyInc.Instance.IncreaseSalary(employeeID, increasePercentage);
                Console.WriteLine($"Employee with ID {employeeID} has got a {increasePercentage:N2}% raise");
            }
            catch (EmployeeNotExistingException e)
            {
                Console.WriteLine(e.Message, employeeID);
            }
        }

        static void TryIncreasingSalary(IDepartment department, double increasePercentage)
        {
            try
            {
                CompanyInc.Instance.IncreaseSalary(department, increasePercentage);
                Console.WriteLine($"The {department} has got a {increasePercentage:N2}% raise");
            }
            catch (NoEmployeesExistInDepartmentException e)
            {
                Console.WriteLine(e.Message, department);
            }
        }

        static void TryIncreasingSalary(List<IDepartment> departments, double increasePercentage)
        {
            departments.ForEach(d => TryIncreasingSalary(d, increasePercentage));
        }
        #endregion
    }
}
