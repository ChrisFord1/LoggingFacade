using Logging.Interfaces;
using System;

namespace Logging
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logFact = new NLog.LogFactory().GetCurrentClassLogger();
            var settings = new ConnectionSettings();

            ILogger logging_adapter = new LoggingAdaptor(logFact, settings);
            
            logging_adapter.Log(new LogEntry(Enums.LoggingEventType.Fatal, "test", logFact.Name));

            logging_adapter.Log(new LogEntry(Enums.LoggingEventType.Debug, "test", logFact.Name));

            logging_adapter.Log(new LogEntry(Enums.LoggingEventType.Information, "test", logFact.Name));

            Test.Test2();

            Console.ReadKey();
        }

        
    }
}
