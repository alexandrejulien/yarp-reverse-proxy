using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NFluent;
using Xunit;
using Peppermint.ReverseProxy;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net;

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

        [Fact]
        public void Ping()
        {
            var client = _host.Server.CreateClient();

            var response = client.GetAsync("/")
                .Result;

            Check.That(response).IsNotNull();
            Check.That(response.StatusCode)
                .IsEqualTo(HttpStatusCode.OK);
        }
    }
}