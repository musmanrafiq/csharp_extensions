using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace LoggingExtensions
{
    public class TimedLog<T> : IDisposable
    {
        private readonly ILogger<T> _logger;
        private readonly LogLevel _level;
        private readonly string _message;
        private readonly object?[] _args;
        private readonly Stopwatch _stopwatch;

        public TimedLog(ILogger<T> logger, LogLevel logLevel,
            string message, object?[] args)
        {
            _logger = logger;
            _level = logLevel;
            _message = message;
            _args = args;
            _stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _stopwatch.Stop();
            _logger.Log(LogLevel.Information, $"{_message} is completed in {_stopwatch.ElapsedMilliseconds} ms ", _args);
        }
    }
}