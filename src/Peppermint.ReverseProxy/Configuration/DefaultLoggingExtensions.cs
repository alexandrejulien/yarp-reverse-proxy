using Microsoft.AspNetCore.HttpLogging;
using Serilog;

namespace Peppermint.ReverseProxy.Configuration
{
    /// <summary>
    /// Default Logging.
    /// </summary>
    public static class DefaultLoggingExtensions
    {
        /// <summary>
        /// Adds the default logging.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddDefaultLogging(
            this IServiceCollection services,
            IConfiguration config)
        {
            // Logging
            var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(config)
            .CreateLogger();

            // Add logger to logging service.
            services.AddLogging(config => config.AddSerilog(logger));
            return services;
        }
    }
}