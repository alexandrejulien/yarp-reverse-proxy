using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using Peppermint.ReverseProxy.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Peppermint.ReverseProxy.Tests
{
    /// <summary>
    /// Country API test.
    /// </summary>
    /// <seealso cref="Peppermint.ReverseProxy.Tests.Abstract.BaseReverseProxyTest" />
    [TestClass]
    public class CountryTest : BaseReverseProxyTest
    {
        /// <summary>
        /// Ping
        /// </summary>
        [TestMethod]
        public void GivenCountryWhenCallApiThenReturnFrenchRepublic()
        {
            var client = _factory.CreateDefaultClient();

            var response = client.GetAsync($"{client.BaseAddress}v3.1/name/France")
                .Result;

            Check.That(response).IsNotNull();
            Check.That(response.StatusCode)
                .IsEqualTo(HttpStatusCode.OK);
            Check.That(response.Content.ReadAsStringAsync().Result)
                .Contains("French Republic");
        }

    }
}
