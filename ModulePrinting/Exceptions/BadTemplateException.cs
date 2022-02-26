using System;

namespace PrintingController.Exceptions
{
    public class BadTemplateException : Exception
    {
        public BadTemplateException() : base() { }

        public BadTemplateException(string message)
            : base(message) { }

        public BadTemplateException(string message, Exception innerException)
            : base(message, innerException) { }

        public BadTemplateException(Exception ex)
            : base(ex?.Message, ex?.InnerException) { }
    }
}
