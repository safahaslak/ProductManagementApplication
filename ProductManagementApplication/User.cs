using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Display(Name = "User Name"), Required]
        public string Name { get; set; }
        [StringLength(50), Display(Name = "User Surname")]
        public string Surname { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50), Display(Name = "Password")]
        public string Password { get; set; }
        [StringLength(50), Display(Name = "Username")]
        public string Username { get; set; }
        [StringLength(50), Display(Name = "User Phonenumber")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }
        [Display(Name = "Is Admin?")]
        public bool IsAdmin { get; set;}
        [Display(Name = "Registration Date")]
        public DateTime CreateDate { get; set;}
    }
}
