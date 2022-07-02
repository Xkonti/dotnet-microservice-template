using Serilog;
using Serilog.Events;

namespace Service.Configuration;

public static class LoggingConfigurator
{
    public static LoggerConfiguration CreateConfiguration(IConfiguration config, LoggerConfiguration? loggerConfig = null)
    {
        var logTemplate = config["Logging:OutputTemplate"] ?? "[{Timestamp:HH:mm:ss}] [{Level:u3}] {Message}{NewLine}{Exception}";
        loggerConfig ??= new LoggerConfiguration();
        loggerConfig
            .Enrich.FromLogContext()

            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)

            .WriteTo.Console(
                outputTemplate: logTemplate
            );

            // .WriteTo.File(
            //     path: config["Logging:FilePath"] ?? "Logs/log.txt",
            //     rollingInterval: RollingInterval.Day,
            //     rollOnFileSizeLimit: true,
            //     retainedFileCountLimit: 14,
            //     outputTemplate: logTemplate
            // );

        return loggerConfig;
    }
}