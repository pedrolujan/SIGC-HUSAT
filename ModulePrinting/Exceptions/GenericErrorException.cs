using System;

namespace PrintingController.Exceptions
{
    public class GenericErrorException : Exception
    {
        public GenericErrorException() : base() { }

        public GenericErrorException(string message)
            : base(message) { }

        public GenericErrorException(string message, Exception innerException)
            : base(message, innerException) { }

        public GenericErrorException(Exception ex)
            : base(ex?.Message, ex?.InnerException) { }
    }
}
