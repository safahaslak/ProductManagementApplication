using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; // Library of StringLenght attribute 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), DisplayName("Category Name"), Required] // stringlenght is an attribute.
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Status")]
        public bool IsActive { get; set; }
        [DisplayName("Date of Create")]
        public DateTime CreateDate { get; set; }
        public virtual List<Product> Products { get; set; } // one category can have more than one product. thats why we used list here.

    }
}
