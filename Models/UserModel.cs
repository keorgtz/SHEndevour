using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace SHEndevour.Models
{
    public class UserModel : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public RoleModel Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber {  get; set; } 
        public string Email { get; set; }
        public bool IsSelected { get; set; }
    }
}
