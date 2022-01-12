using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using totvs_desafio.Interfaces;
using totvs_desafio.Models;

namespace totvs_desafio.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                            .Where(property => property.Entity is IBaseEntity && (property.State == EntityState.Added || property.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    ((IBaseEntity)entityEntry.Entity).modified = DateTime.Now;
                }

                else if (entityEntry.State == EntityState.Added)
                {
                    ((IBaseEntity)entityEntry.Entity).created = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
}
