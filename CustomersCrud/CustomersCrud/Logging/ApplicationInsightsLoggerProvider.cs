using Microsoft.Extensions.Logging;

namespace CustomersCrud.Logging
{
    public class ApplicationInsightsLoggerProvider : ILoggerProvider
    {
        private readonly LoggingSettings settings;

        public ApplicationInsightsLoggerProvider(LoggingSettings settings)
        {
            this.settings = settings;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ApplicationInsightsLogger(settings.InstrumentationKey, settings.DeveloperMode);
        }

        public void Dispose()
        {
            
        }
    }
}
