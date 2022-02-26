using System;

namespace selferviceSIGC.Exceptions
{
    public class FormatException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormatException" /> class.
        /// </summary>
        public FormatException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormatException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public FormatException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormatException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public FormatException(string message, Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormatException"/> class.
        /// </summary>
        /// <param name="exception">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public FormatException(Exception ex)
            : base(ex?.Message, ex?.InnerException) { }
    }
}