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

        ILogger _logger = loggerFactory.CreateLogger<Program>();
        _logger.Log(LogLevel.Information, "test");
        //using var _ = _logger.TimedLog();
        Console.ReadKey();
    }
}
