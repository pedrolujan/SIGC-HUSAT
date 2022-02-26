using System;

namespace PrintingController.Exceptions
{
    public class TemplateNotFoundException : Exception
    {
        public TemplateNotFoundException() : base() { }

        public TemplateNotFoundException(string message)
            : base(message) { }

        public TemplateNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }

        public TemplateNotFoundException(Exception ex)
            : base(ex?.Message, ex?.InnerException) { }
    }
}
