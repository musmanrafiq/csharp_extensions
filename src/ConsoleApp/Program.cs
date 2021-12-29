using LoggingExtensions;
using Microsoft.Extensions.Logging;

class Program
{
    static void Main(string[] args)
    {
       using var loggerFactory = LoggerFactory.Create(builder =>
       {
           builder
                   .AddFilter("Microsoft", LogLevel.Information)
                   .AddFilter("System", LogLevel.Information)
                   .AddFilter("ConsoleApp.Program", LogLevel.Information)
                   .AddConsole();
            
        });

        ILogger<Program> _logger = loggerFactory.CreateLogger<Program>();
        // normal log
        _logger.Log(LogLevel.Information, "test");
        // timed logger
        using var _ = _logger.TimedLogg("timedLog");
    }
}
