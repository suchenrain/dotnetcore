using System;
using System.Text;

namespace EA.Common.Facade
{
    public static class LoggerHelper
    {
        /// <summary>
        /// Get Exception Details information
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>string</returns>
        public static string GetExceptionDetails(Exception ex)
        {
            StringBuilder errorString = new StringBuilder();
            errorString.AppendLine("An Error occured.");
            Exception inner = ex;
            while (inner != null)
            {
                errorString.Append("Error Message:");
                errorString.AppendLine(ex.Message);
                errorString.Append("Stack Trace");
                errorString.AppendLine(ex.StackTrace);
                inner = inner.InnerException;
            }
            return errorString.ToString();
        }
    }
}