using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class ConnectionSettings
    {
        public string AccessKey { get; set; }

        public string AccessSecret { get; set; }

        public string Region { get; set; }

        public string LogGroupName { get; set; }

        public string LogStreamName { get; set; }

        public ConnectionSettings Configure(string accessKey, string accessSecret, string region, string logGroupName, string logStreamName)
        {
            var settings = new ConnectionSettings
            {
                AccessKey = accessKey,
                AccessSecret = accessSecret,
                Region = region,
                LogGroupName = logGroupName,
                LogStreamName = logStreamName
            };
            return settings;
        }
    }
}
