namespace RepositoryLayer.Migrations
{
    using DomainLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RepositoryLayer.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepositoryLayer.MyDbContext context)
        {

            // write your code here to add intial data

            var products = new List<Product>
            {
                new Product { ProductName = "Product A", Category = "Category X" },
                new Product { ProductName = "Product B", Category = "Category Y" },
                new Product { ProductName = "Product C", Category = "Category Z" },

            };


            products.ForEach(product => context.Products.Add(product));


            context.SaveChanges();
        }
    }
}

