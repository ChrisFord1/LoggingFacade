using Logging.Interfaces;
using Logging.Enums;

namespace Logging
{
    public class LoggingAdaptor : ILogger
    {
        private readonly NLog.ILogger m_Adaptee;

        public LoggingAdaptor(NLog.ILogger adaptee)
        {
            m_Adaptee = adaptee;
        }

        public void Log(LogEntry entry)
        {
            //Here invoke m_Adaptee
            if (entry.Severity == LoggingEventType.Debug)
            {
                m_Adaptee.Debug(entry.Message, entry.Exception);
            }
            else if (entry.Severity == LoggingEventType.Information)
            {
                m_Adaptee.Info(entry.Message, entry.Exception);
            }
            else if (entry.Severity == LoggingEventType.Warning)
            {
                m_Adaptee.Warn(entry.Message, entry.Exception);
            }
            else if (entry.Severity == LoggingEventType.Error)
            {
                m_Adaptee.Error(entry.Message, entry.Exception);
            }
            else
            {
                m_Adaptee.Fatal(entry.Message, entry.Exception);
            }
        }
    }
}
