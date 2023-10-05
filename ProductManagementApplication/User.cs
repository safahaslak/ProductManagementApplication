using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set;}
        public DateTime CreateDate { get; set;}
    }
}
