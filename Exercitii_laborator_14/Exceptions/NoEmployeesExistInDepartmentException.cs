using System;


namespace Exercitii_laborator_14.Exceptions
{
    class NoEmployeesExistInDepartmentException : Exception
    {
        private const string message = "No employees exists in {0}";

        public NoEmployeesExistInDepartmentException() : base(message)
        {
        }
    }
}
