using System;
using System.Data.Entity;
using CustomerManagement.Data.DAO;
using CustomerManagement.Data.Mappings;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Reflection;

namespace CustomerManagement.Data
{
    public class CustomerManagementDbContext:DbContext, ICustomerManagementDbContext, IDisposable
    {
        static CustomerManagementDbContext()
        {
            Database.SetInitializer<CustomerManagementDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(CustomerMap).Assembly);
        }

        public CustomerManagementDbContext() : base("CustomerManagementDbContext") { }

        public DbSet<Customer> Customers { get; set; }
    }

    public interface ICustomerManagementDbContext
    {
        Database Database { get; }
        int SaveChanges();
        DbSet<Customer> Customers { get; set; }
    }
}
