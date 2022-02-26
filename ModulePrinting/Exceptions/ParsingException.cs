using System;

namespace PrintingController.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base() { }

        public ValidationException(string message)
            : base(message) { }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException) { }

        public ValidationException(Exception ex)
            : base(ex?.Message, ex?.InnerException) { }
    }
}
