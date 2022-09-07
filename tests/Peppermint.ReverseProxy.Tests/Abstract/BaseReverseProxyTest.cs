using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
