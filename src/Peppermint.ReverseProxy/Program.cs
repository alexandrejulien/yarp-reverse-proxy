using Peppermint.ReverseProxy.Configuration;
using Peppermint.ReverseProxy.Resources;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Peppermint.ReverseProxy.Tests")]

namespace Peppermint.ReverseProxy
{
    /// <summary>
    /// Startup program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="Program"/> class from being created.
        /// </summary>
        private Program() { }

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            // Configuration
            var config = ReverseProxyConfiguration.Configure();

            // Dependencies injection
            services.AddDefaultLogging(config);
            services.AddYarpReverseProxy(builder);

            var app = builder.Build();

            app.UseRouting();
            app.UseWebSockets();
            app.UseResponseCompression();
            app.UseHttpLogging();
            app.UseHealthChecks(Settings.HealthEndpoint);

            // Register the reverse proxy routes
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy();
            });

            app.Logger.LogInformation(message: Logs.Welcome,
                DateTime.Now.ToShortTimeString());
            app.Run();
        }
    }
}