namespace ProductManagementApplication.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductManagementApplication.Data.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //turned this to the true 
            AutomaticMigrationDataLossAllowed = true; // added this.
            ContextKey = "ProductManagementApplication.Data.DatabaseContext";
        }

        protected override void Seed(ProductManagementApplication.Data.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.
            //seed method enable only when the database created.
            if (!context.Users.Any())
            {
                context.Users.Add(new Entities.User()
                {
                    CreateDate = System.DateTime.Now,
                    Email = "haslaksafa1@gmail.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "Safa",
                    Username = "Cosmo",
                    Password = "7946138520"
                });
                context.SaveChanges(); // these changes will be saved after this.
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
