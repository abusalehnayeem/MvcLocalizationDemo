using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcLocalizationDemo.Models;

namespace MvcLocalizationDemo.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext():base("name=LocalizationDB")
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public DbSet<ResourceEntry> ResourceEntry { get; set; }
        public DbSet<Employees> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}