using Peppermint.ReverseProxy;
using Peppermint.ReverseProxy.Resources;
using Serilog;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Peppermint.ReverseProxy.Tests")]

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Configuration
var config = new ConfigurationBuilder()
.AddJsonFile(Settings.AppSettingsFileName)
.AddJsonFile(Settings.ReverseProxySettingsFile)
.Build();

// Logging
var logger = new LoggerConfiguration()
.ReadFrom.Configuration(config)
.CreateLogger();

// Yarp Configuration
var yarpConfig = builder.Configuration.GetSection(Settings.YarpConfigSection);

// Dependency injection
services.AddLogging(config => config.AddSerilog(logger));
services.AddReverseProxy().LoadFromConfig(yarpConfig);

var app = builder.Build();

// Register the reverse proxy routes
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapReverseProxy();
});

app.Run();

public partial class Program 
{ 
    // void
}
