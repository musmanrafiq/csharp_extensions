using Microsoft.Extensions.Logging;

namespace LoggingExtensions
{
    public static class LoggerExtension
    {
        public static IDisposable TimedLogg<T>(this ILogger<T> logger, string message, LogLevel level = LogLevel.Information, params object?[] args)
        {
            return new TimedLog<T>(logger, level, message, args);
        }
    }
}
