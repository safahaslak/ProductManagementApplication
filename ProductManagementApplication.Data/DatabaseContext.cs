﻿using ProductManagementApplication.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Data
{
    public class DatabaseContext : DbContext // "DbContext" is an EntityFramework class.
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DatabaseContext() : base ("name=ProductManagementApplicationDB")
        {
            Database.SetInitializer(new DbInitializer()); 
        }
    }
}
