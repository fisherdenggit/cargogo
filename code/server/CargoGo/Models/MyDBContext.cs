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
        public DbSet<BankAccout> BankAccouts { get; set; }
        public DbSet<CompanyDeliveryAddress> CompanyDeliveryAddresses { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesDetail> SalesDetails { get; set; }
    }
}