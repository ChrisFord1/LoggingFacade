using Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logFact = new NLog.LogFactory().GetCurrentClassLogger();
            
            ILogger logging_adapter = new LoggingAdaptor(logFact);

            logging_adapter.Log(new LogEntry(Enums.LoggingEventType.Fatal, "test"));

            Console.ReadKey();
        }
    }
}
