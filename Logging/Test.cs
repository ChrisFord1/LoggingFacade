using Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public static class Test
    {
        public static void Test2()
        {
            var logFact = new NLog.LogFactory().GetCurrentClassLogger();
            var setting = new ConnectionSettings();

            ILogger logging_adapter = new NLogLoggingAdaptor(logFact, setting);

            logging_adapter.Log(new LogEntry(Enums.LoggingEventType.Fatal, "test", logFact.Name));

            logging_adapter.Log(new LogEntry(Enums.LoggingEventType.Debug, "test", logFact.Name));

            logging_adapter.Log(new LogEntry(Enums.LoggingEventType.Information, "test", logFact.Name));


        }
    }
}
