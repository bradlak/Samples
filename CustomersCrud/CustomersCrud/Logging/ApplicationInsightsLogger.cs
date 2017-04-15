using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Logging;
using System;

namespace CustomersCrud.Logging
{
    public class ApplicationInsightsLogger : ILogger
    {
        private readonly TelemetryClient telemetryClient;

        public ApplicationInsightsLogger(string instrumentationKey, bool developerMode)
        {
            telemetryClient = new TelemetryClient();
            TelemetryConfiguration.Active.TelemetryChannel.DeveloperMode = developerMode;
            telemetryClient.InstrumentationKey = instrumentationKey;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new JustDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.Information;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if(exception != null)
            {
                telemetryClient.TrackException(new ExceptionTelemetry(exception));
            }

            var message = string.Empty;
            if (formatter != null)
            {
                message = formatter(state, exception);
            }
            else
            {
                if (state != null)
                {
                    message += state;
                }
            }
            if (!string.IsNullOrEmpty(message))
            {
                telemetryClient.TrackTrace(message, GetSeverityLevel(logLevel));
            }
        }

        private SeverityLevel GetSeverityLevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Critical:
                    return SeverityLevel.Critical;
                case LogLevel.Warning:
                    return SeverityLevel.Warning;
                case LogLevel.Information:
                    return SeverityLevel.Information;
                case LogLevel.Error:
                    return SeverityLevel.Error;
                default:
                    return SeverityLevel.Verbose;
            }
        }

        private class JustDisposable : IDisposable
        {
            public void Dispose()
            {
                
            }
        }
    }
}
