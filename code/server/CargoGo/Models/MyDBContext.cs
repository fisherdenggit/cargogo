using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CargoGo.Models
{
    public class MyDBContext:DbContext
    {
        public MyDBContext() : base("CargoGo")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDBContext>());
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<MyUser> MyUsers { get; set; }
    }
}