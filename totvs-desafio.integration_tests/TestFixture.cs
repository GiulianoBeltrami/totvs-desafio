using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using totvs_desafio;
using totvs_desafio.Context;

namespace totvs_desafio_integration_tests
{

    public class TestFixture
    {
        protected readonly HttpClient _testClient;

        public TestFixture()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => {
                    builder.ConfigureServices(services =>
                    {
                        var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(UserContext));
                        services.Remove(serviceDescriptor);
                        services.AddDbContext<UserContext>(option =>
                        {
                            option.UseInMemoryDatabase("TestDb");
                        });
                    });
                });
            _testClient = appFactory.CreateClient();
        }
    }
}
