using ProductManagementApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; } // primarykey
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public bool IsActive { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryId { get; set; } // foreignkey
        public virtual Category Category { get; set; } // every product will have one category.

    }
}
