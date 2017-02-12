using Logging.Enums;
using Newtonsoft.Json;
using System;
using System.Diagnostics.Contracts;

namespace Logging
{
    public class LogEntry
    {
        public readonly LoggingEventType Severity;
        public readonly string Message;
        public readonly Exception Exception;
        public readonly string ClassName;

        public LogEntry(LoggingEventType severity, string message, string className, Exception exception = null)
        {
            this.Severity = severity;
            this.Message = message;
            this.ClassName = className;
            this.Exception = exception;
        }

        
    }
}
