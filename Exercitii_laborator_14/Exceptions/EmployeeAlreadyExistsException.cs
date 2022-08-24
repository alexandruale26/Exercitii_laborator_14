using System;


namespace Exercitii_laborator_14.Exceptions
{
    class EmployeeAlreadyExistsException : Exception
    {
        private const string message = "Employee {0} with ID {1} already exists";

        public EmployeeAlreadyExistsException() : base(message)
        {
        }
    }
}
