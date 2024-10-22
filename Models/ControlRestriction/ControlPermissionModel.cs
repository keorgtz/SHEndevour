using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHEndevour.Models.ControlRestriction
{
    public class ControlPermissionModel
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserModel? User { get; set; }

        public string? ControlName { get; set; }
        public string? ViewName { get; set; }

        public bool IsVisible { get; set; } = true;
        public bool IsEnabled { get; set; } = true;
    }
}
