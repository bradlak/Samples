using Microsoft.Extensions.Logging;

namespace CustomersCrud.Logging
{
    public static class LoggerFactoryExtensions
    {
        public static ILoggerFactory AddApplicationInsightsLogger(this ILoggerFactory factory, LoggingSettings settings)
        {
            factory.AddProvider(new ApplicationInsightsLoggerProvider(settings));
            return factory;
        }
    }
}
