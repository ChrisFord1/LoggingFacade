using Logging.Interfaces;
using Logging.Enums;
using NLog.Config;
using NLog.Targets;
using NLog.AWS.Logger;
using NLog;
using System;
using Newtonsoft.Json;
using Amazon.Runtime;

namespace Logging
{
    public class LoggingAdaptor : Interfaces.ILogger
    {
        private readonly NLog.ILogger m_Adaptee;

        public LoggingAdaptor(NLog.ILogger adaptee, ConnectionSettings settings)
        {
            m_Adaptee = adaptee;
            Configure(settings);
        }

        public void Log(LogEntry entry)
        {
            var jsonMessage = NLogToJson(entry);
            //Here invoke m_Adaptee
            if (entry.Severity == LoggingEventType.Debug)
            {
                m_Adaptee.Debug(jsonMessage);
            }
            else if (entry.Severity == LoggingEventType.Information)
            {
                m_Adaptee.Info(jsonMessage);
            }
            else if (entry.Severity == LoggingEventType.Warning)
            {
                m_Adaptee.Warn(jsonMessage);
            }
            else if (entry.Severity == LoggingEventType.Error)
            {
                m_Adaptee.Error(jsonMessage);
            }
            else
            {
                m_Adaptee.Fatal(jsonMessage);
            }
        }

        private string NLogToJson(LogEntry entry)
        {
            var logEvent = new LogEvent()
            {
                HappenedOn = DateTime.Now.ToLongDateString(),
                EventId = string.Empty,
                ClassName = entry.ClassName,
                LogLevel = entry.Severity.ToString(),
                Message = entry.Message,
                Exception = entry.Exception != null ? entry.Exception.Message : string.Empty,
            };

            try
            {
                var jsonObject = JsonConvert.DeserializeObject<object>(entry.Message);
                if (jsonObject != null)
                    logEvent.Message = jsonObject;
            }
            catch (Exception)
            {
                // ignored
            }


            return JsonConvert.SerializeObject(logEvent);
        }

        private void Configure(ConnectionSettings settings)
        {
            var config = new LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            var cred = new BasicAWSCredentials(settings.AccessKey, settings.AccessSecret);

            var awsTarget = new AWSTarget()
            {
                LogGroup = settings.LogGroupName,
                Region = settings.Region,
                Credentials = cred
            };

            config.AddTarget("aws",awsTarget);

            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, awsTarget));

            m_Adaptee.Factory.Configuration = config;
        }
    }
}
