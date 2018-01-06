namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CargoGo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CargoGo.Models.MyDBContext>
    {
        public Configuration()
        {
            //是否自动将Model类的设计改变映射到数据库，默认false
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CargoGo.Models.MyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Trucks.Add(new Truck("渝B3178", "大型板车"));
            //context.Trucks.Add(new Truck("川W62945", "大型货车","关羽"));
            //context.Trucks.Add(new Truck("川W23998", "大型货车", "张飞","11011001100"));
            context.Companies.Add(new Company { CompanyName = "攀枝花市正源科技有限责任公司" });
            //context.Configuration.ProxyCreationEnabled = false;
        }
    }
}
