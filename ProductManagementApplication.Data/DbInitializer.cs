using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Data
{
    internal class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext> //CreateDatabaseIfNotExists<DatabaseContext> //if there is no database, check the databasecontext and create the db base on that.
    {
        protected override void Seed(DatabaseContext context)
        {
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
            base.Seed(context);
        }
    }
}
