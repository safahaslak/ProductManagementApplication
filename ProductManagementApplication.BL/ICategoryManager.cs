using ProductManagementApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.BL
{
    public interface ICategoryManager
    {
        List<Category> GetCategories();
        void Add(Category category);
        Category GetCategory(int id);
        void Update(Category category);
        void Delete(Category category);
        int Save();
    }
}
