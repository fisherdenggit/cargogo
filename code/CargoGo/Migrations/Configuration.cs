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
            //�Ƿ��Զ���Model�����Ƹı�ӳ�䵽���ݿ⣬Ĭ��false
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
            //context.Trucks.Add(new Truck("��B3178", "���Ͱ峵"));
            //context.Trucks.Add(new Truck("��W62945", "���ͻ���","����"));
            //context.Trucks.Add(new Truck("��W23998", "���ͻ���", "�ŷ�","11011001100"));
            context.Companies.Add(new Company { CompanyName = "��֦������Դ�Ƽ��������ι�˾" });
            //context.Configuration.ProxyCreationEnabled = false;
        }
    }
}
