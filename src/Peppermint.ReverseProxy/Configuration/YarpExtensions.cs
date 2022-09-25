using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.DependencyInjection;
using Peppermint.ReverseProxy.Resources;

namespace Peppermint.ReverseProxy.Configuration
{
    /// <summary>
    /// Yarp extensions.
    /// </summary>
    public static class YarpExtensions
    {
        /// <summary>
        /// Adds the yarp reverse proxy.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IServiceCollection AddYarpReverseProxy(
            this IServiceCollection services,
            WebApplicationBuilder builder)
        {
            // Yarp Configuration
            var yarpConfig = builder.Configuration.GetSection(Settings.YarpConfigSection);

            services.AddHealthChecks();
            services.AddResponseCompression();


            // Reverse proxy
            services.AddReverseProxy().LoadFromConfig(yarpConfig);
            return services;
        }
    }
}