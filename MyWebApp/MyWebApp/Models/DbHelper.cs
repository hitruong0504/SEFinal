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

        public DbSet<Account> accounts { get; set; }
    }
}