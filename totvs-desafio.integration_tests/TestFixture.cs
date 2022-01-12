using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using totvs_desafio;
using totvs_desafio.Context;

namespace totvs_desafio_integration_tests
{

    public class TestFixture : IDisposable
    {
        private DbContext _context;

        public TestFixture()
        {
            var dbOptions = new DbContextOptionsBuilder<DbContext>().UseNpgsql("User ID =postgres;Password=32411680;Server=localhost;Port=5432;Database=totvs-integration-tests");
            _context = new DbContext(dbOptions.Options);
            _context.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
