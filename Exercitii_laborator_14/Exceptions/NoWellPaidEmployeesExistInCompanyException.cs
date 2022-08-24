using System;


namespace Exercitii_laborator_14.Exceptions
{
    class NoWellPaidEmployeesExistInCompanyException : Exception
    {
        private const string message = "No well paid employees exist in Company";

        public NoWellPaidEmployeesExistInCompanyException() : base(message)
        {
        }
    }
}
