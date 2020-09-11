using System;

namespace HealthSanctuary.Core.Exceptions
{
    public class MealUsedException : ApplicationException
    {
        public MealUsedException()
        {
        }

        public MealUsedException(string message) : base(message)
        {
        }

        public MealUsedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
