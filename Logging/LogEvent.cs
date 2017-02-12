using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class LogEvent
    {
        public string HappenedOn { get; set; }
        public string EventId { get; set; }
        public string ClassName { get; set; }
        public string LogLevel { get; set; }
        public object Message { get; set; }
        public string Exception { get; set; }
    }
}
