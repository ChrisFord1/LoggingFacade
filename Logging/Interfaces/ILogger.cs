namespace Logging.Interfaces
{
    public interface ILogger
    {
        void Configure();
        void Log(LogEntry entry);
    }
}
