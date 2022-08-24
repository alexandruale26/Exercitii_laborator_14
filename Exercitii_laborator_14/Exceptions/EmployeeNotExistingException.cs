using System;


namespace Exercitii_laborator_14.Exceptions
{
    [Serializable]
    internal class EmployeeNotExistingException : Exception
    {
        private const string message = "Employee with ID {0} is not existing";

        public EmployeeNotExistingException() : base(message)
        {
        }
    }
}