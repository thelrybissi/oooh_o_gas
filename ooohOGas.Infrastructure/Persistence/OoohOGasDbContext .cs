using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ooohOGas.Domain.Entities;

namespace ooohOGas.Infrastructure.Persistence
{
    public class OoohOGasDbContext : DbContext
    {
        public OoohOGasDbContext(DbContextOptions<OoohOGasDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");

            base.OnModelCreating(modelBuilder);
        }
    }
}
