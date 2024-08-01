using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SHEndevour.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; } // Campo Id único

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
