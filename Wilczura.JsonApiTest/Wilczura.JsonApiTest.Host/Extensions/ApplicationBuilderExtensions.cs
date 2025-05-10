namespace Wilczura.JsonApiTest.Host.Extensions;

public static class ApplicationBuilderExtensions
{
    public static ILogger GetStartupLogger(this IHostApplicationBuilder app)
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug);
            builder.AddSimpleConsole(config =>
            {
                config.IncludeScopes = false;
                config.SingleLine = true;
            });
        });

        var logger = loggerFactory.CreateLogger<Program>();

        if (logger == null)
        {
            throw new Exception(nameof(logger));
        }

        logger.LogInformation("Logger created");
        // logger.LogInformation("{systemInfo}", SystemInfo.GetInfo());

        return logger;
    }
}
