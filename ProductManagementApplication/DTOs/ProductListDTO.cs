using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.DTOs
{
    public class ProductListDTO
    {
        public int Id { get; set; }
        [StringLength(50), Display(Name = "Product Name"), Required]
        public string Name { get; set; }
        [StringLength(50)]
        public string Brand { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        [StringLength(100), Display(Name = "Product's image")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
    }
}
