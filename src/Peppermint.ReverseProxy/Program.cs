using Peppermint.ReverseProxy;
using Peppermint.ReverseProxy.Configuration;
using Peppermint.ReverseProxy.Resources;
using Serilog;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Peppermint.ReverseProxy.Tests")]
namespace Peppermint.ReverseProxy
{
    /// <summary>
    /// Startup program.
    /// </summary>
    public partial class Program
    {
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

            // Register the reverse proxy routes
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy();
            });

            app.Logger.LogInformation(message: Logs.Welcome);
            app.Run();
        }
    }
}
