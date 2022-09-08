using Microsoft.AspNetCore.Mvc.Testing;

namespace Peppermint.ReverseProxy.Tests.Abstract
{
    public abstract class BaseReverseProxyTest
    {
        /// <summary>
        /// Web application factory.
        /// </summary>
        public readonly WebApplicationFactory<Program> _factory = new();

        /// <summary>
        /// Startup constructor.
        /// </summary>
        protected BaseReverseProxyTest()
        {
            _factory = new WebApplicationFactory<Program>();
        }
    }
}