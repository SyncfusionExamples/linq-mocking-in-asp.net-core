using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication.CustomerEntity
{
    public class CustomerEntity : DbContext
    {
        public CustomerEntity()
        {
        }

        public CustomerEntity(DbContextOptions<CustomerEntity> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerData> CustomerData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Connectionstrings"); // Pass valid connectionstring here.
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerData>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.HasIndex(e => e.email)
                    .IsUnique();
            });
        }
        }
}
