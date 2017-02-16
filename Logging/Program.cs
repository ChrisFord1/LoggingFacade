using System;
using NLog;
using ILogger = Logging.Interfaces.ILogger;
using NLog.Fluent;

namespace Logging
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logFact = new NLog.LogFactory().GetCurrentClassLogger();
            var settings = new ConnectionSettings().Configure("","","","","");

            ILogger logging_adapter = new NLogLoggingAdaptor(logFact, settings);
            
            logging_adapter.Log(new LogEntry(Enums.LoggingEventType.Fatal, "test", logFact.Name));

            logging_adapter.Log(new LogEntry(Enums.LoggingEventType.Debug, "test", logFact.Name));

            logging_adapter.Log(new LogEntry(Enums.LoggingEventType.Information, "test", logFact.Name));

            Test.Test2();

            Console.ReadKey();
        }

        
    }
}
