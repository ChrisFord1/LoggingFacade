using Logging.Enums;
using Logging.Interfaces;
using System;

namespace Logging.Extensions
{
    public static class LoggerExtensions
    {
        public static void Log(this ILogger logger, string message, string className)
        {
            logger.Log(new LogEntry(LoggingEventType.Information, message, className));
        }

        public static void Log(this ILogger logger, Exception exception)
        {
            logger.Log(new LogEntry(LoggingEventType.Error, exception.Message, string.Empty, exception));
        }
    }
}
