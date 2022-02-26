using System;

namespace PrintingController.Exceptions
{
    public class ParsingException : Exception
    {
        public ParsingException() : base() { }

        public ParsingException(string message)
            : base(message) { }

        public ParsingException(string message, Exception innerException)
            : base(message, innerException) { }

        public ParsingException(Exception ex)
            : base(ex?.Message, ex?.InnerException) { }
    }
}
