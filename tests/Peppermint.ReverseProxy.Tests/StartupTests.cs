using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NFluent;
using Xunit;
using Peppermint.ReverseProxy;

namespace Peppermint.ReverseProxy.Tests
{
    public class StartupTests
    {
        private readonly WebApplicationFactory<Program> _host;

        public StartupTests()
        {
            // Arrange
            _host = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {

                });
            });
        }

        [Fact]
        public void Startup()
        {
            Check.That(_host.Server)
                .IsNotNull();
        }
    }
}