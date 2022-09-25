using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using Peppermint.ReverseProxy.Tests.Abstract;
using System.Net;

namespace Peppermint.ReverseProxy.Tests
{
    /// <summary>
    /// Startup tests.
    /// </summary>
    [TestClass]
    public class StartupTests : BaseReverseProxyTest
    {
        /// <summary>
        /// Startup test
        /// </summary>
        [TestMethod]
        public void GivenReverseProxyThenStartup()
        {
            Check.That(_factory.Server)
                .IsNotNull();
        }

        /// <summary>
        /// Http Ping.
        /// </summary>
        [TestMethod]
        public void GivenReverseProxyAndBaseUrlThenReturnPing()
        {
            var client = _factory.CreateDefaultClient();

            var response = client.GetAsync($"{client.BaseAddress}")
                .Result;
            Check.That(response).IsNotNull();
        }

        /// <summary>
        /// Givens the reverse proxy and base URL then check health.
        /// </summary>
        [TestMethod]
        public void GivenReverseProxyAndBaseUrlThenCheckHealth()
        {
            var client = _factory.CreateDefaultClient();

            var response = client.GetAsync($"{client.BaseAddress}healthz")
                .Result;

            Check.That(response.StatusCode)
                .IsEqualTo(HttpStatusCode.OK);
        }
    }
}