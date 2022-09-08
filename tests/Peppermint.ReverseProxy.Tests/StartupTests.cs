using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using Peppermint.ReverseProxy.Tests.Abstract;

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
    }
}