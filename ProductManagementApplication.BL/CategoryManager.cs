using ProductManagementApplication.Data;
using ProductManagementApplication.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.BL
{
    public class CategoryManager : ICategoryManager
    {
        DatabaseContext context = new DatabaseContext();
        public void Add(Category category)
        {
            context.Categories.Add(category);
        }

        public void Delete(Category category)
        {
            context.Categories.Remove(category);
        }

        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return context.Categories.Find(id);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(Category category)
        {
            context.Categories.AddOrUpdate(category);
        }
    }
}
