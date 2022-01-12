using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Http;
using totvs_desafio;
using totvs_desafio.Context;

namespace totvs_desafio_integration_tests
{

    public class TestFixture
    {
        protected readonly HttpClient _testClient;

        public TestFixture()
        {
            var factory = new WebApplicationFactory<Startup>();
            _testClient = factory.CreateClient();
        }
    }
}
