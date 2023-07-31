using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class MyDbContext : DbContext 
    {
        public MyDbContext() : base("MyDbContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
// How to do Initial Migration 

// 1.Open the Package Manager Console in Visual Studio and run the following command to enable migrations for your project.( select repositoryLayer as default)
// 2.run the following command  "Enable-Migrations"   to enable migrations
// 3.Write you code in Configuration.cs to add your data. 
// 4.Run the following command  "Add-Migration InitialCreate"   to generate an initial migration
// 5.Run the following command  "Update-Database"  to apply the migration and create the database