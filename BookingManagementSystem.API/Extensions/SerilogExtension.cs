using Serilog;

namespace BookingManagementSystem.API.Extensions
{
    public static class SerilogExtension
    {
        public static void AddCustomSerilog(this ILoggingBuilder logBuilder )
        {
            var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(new ConfigurationBuilder()
            .AddJsonFile("serilog-config.json")
            .Build())
            .Enrich.FromLogContext()
            .CreateLogger();
            logBuilder.ClearProviders();
            logBuilder.AddSerilog(logger);
        }
    }
}
