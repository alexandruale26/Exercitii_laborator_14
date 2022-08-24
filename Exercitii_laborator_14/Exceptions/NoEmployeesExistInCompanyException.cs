using System;

namespace Exercitii_laborator_14.Exceptions
{
    class NoEmployeesExistInCompanyException : Exception
    {
        private const string message = "No employees exist in Company";

        public NoEmployeesExistInCompanyException() : base(message)
        {
        }
    }
}
