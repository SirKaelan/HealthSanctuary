using System;

namespace HealthSanctuary.Core.Exceptions
{
    public class WorkoutOwnerException : ApplicationException
    {
        public WorkoutOwnerException()
        {
        }

        public WorkoutOwnerException(string message) : base(message)
        {
        }

        public WorkoutOwnerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
