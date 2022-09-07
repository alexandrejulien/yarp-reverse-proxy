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
using Microsoft.AspNetCore.Http;
using Peppermint.ReverseProxy.Configuration;
using Peppermint.ReverseProxy.Tests.Abstract;

namespace Peppermint.ReverseProxy.Tests
{

    /// <summary>
    /// Startup tests.
    /// </summary>
    public class StartupTests : BaseReverseProxyTest
    {
        /// <summary>
        /// Startup test
        /// </summary>
        [Fact]
        public void GivenReverseProxyThenStartup()
        {
            Check.That(_factory.Server)
                .IsNotNull();
        }

        /// <summary>
        /// Http Ping.
        /// </summary>
        [Fact]
        public void GivenReverseProxyAndBaseUrlThenReturnPing()
        {
            var client = _factory.CreateDefaultClient();

            var response = client.GetAsync($"{client.BaseAddress}")
                .Result;
            Check.That(response).IsNotNull();
        }
    }
}