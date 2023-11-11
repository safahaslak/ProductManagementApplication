using ProductManagementApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductManagementApplication.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; } // primarykey
        [StringLength(50), Display(Name = "Product Name"), Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [StringLength(50)]
        public string Brand { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        [StringLength(100),Display(Name = "Product's image")]
        public string Image { get; set; }
        [StringLength(100)]
        public string Image2 { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryId { get; set; } // foreignkey
        [ScaffoldColumn(false)]
        public virtual Category Category { get; set; } // every product will have one category.

    }
}
