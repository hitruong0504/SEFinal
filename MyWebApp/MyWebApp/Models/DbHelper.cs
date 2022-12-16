using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class DbHelper : DbContext
    {
        public DbHelper() : base("name=MyWebApp")
        {
            Database.SetInitializer<DbHelper>(new CreateDatabaseIfNotExists<DbHelper>());
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Account> account { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payment> payment { get; set; }
        public DbSet<Cart> Cart { get; set; }

    }
}