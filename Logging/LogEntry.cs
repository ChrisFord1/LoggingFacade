using Logging.Enums;
using System;
using System.Diagnostics.Contracts;

namespace Logging
{
    public class LogEntry
    {
        public readonly LoggingEventType Severity;
        public readonly string Message;
        public readonly Exception Exception;

        public LogEntry(LoggingEventType severity, string message, Exception exception = null)
        {
            //Requires.IsNotNullOrEmpty(message, "message");
            //Requires.IsValidEnum(severity, "severity");
            this.Severity = severity;
            this.Message = message;
            this.Exception = exception;
        }
    }
}
