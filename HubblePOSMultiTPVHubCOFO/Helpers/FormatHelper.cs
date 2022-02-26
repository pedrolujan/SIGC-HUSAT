using HubFirebase.Models;
using System;

namespace HubFirebase
{
    public class FormatHelper
    {
        #region Error messages related

        internal static string FormatErrorMessage(string message, Exception ex)
        {
            string output = string.Empty;
            try
            {
                string validatedMessagePortion = message ?? string.Empty;
                string validatedExceptionMessagePortion = ex != null ? $" - MÁS INFO: {ex.Message}" : string.Empty;
                string validatedInnerExceptionMessagePortion = FormatInnerExceptionErrorMessage(ex.InnerException);
                string validatedStackTracePortion = (ex != null && ex.StackTrace != null) ? $" - STACK TRACE: {ex.StackTrace}" : string.Empty;

                output = validatedMessagePortion + validatedExceptionMessagePortion + validatedInnerExceptionMessagePortion + validatedStackTracePortion;
            }
            catch { }
            return output;
        }

        internal static string FormatInnerExceptionErrorMessage(Exception inputInnerException)
        {
            string output = string.Empty;
            try
            {
                output = inputInnerException != null ? $" - INNER EXCEPTION: {inputInnerException.Message}" : string.Empty;
                if (inputInnerException != null && inputInnerException.InnerException != null)
                {
                    output += FormatInnerExceptionErrorMessage(inputInnerException.InnerException);
                }
            }
            catch { }
            return output;
        }

        #endregion Error messages related
       
        internal static GenericResponse<dynamic> fnFormatobjectFirebase(global::Firebase.Database.Streaming.FirebaseEvent<dynamic> firebaseEvent)
        {
            GenericResponse<dynamic> generic = new GenericResponse<dynamic>();
            generic.eventSource = (int)firebaseEvent.EventSource;
            generic.evenType = (int)firebaseEvent.EventType;
            generic.key = firebaseEvent.Key;
            generic.obj = firebaseEvent.Object;
            return generic;
        }

    }
}
