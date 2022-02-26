using System;

namespace PrintingController.Exceptions { 
    public class PrintingErrorException : Exception
    {
        public PrintingErrorException() : base() { }

        public PrintingErrorException(string message)
            : base(message) { }

        public PrintingErrorException(string message, Exception innerException)
            : base(message, innerException) { }

        public PrintingErrorException(Exception ex)
            : base(ex?.Message, ex?.InnerException) { }
    }
}
