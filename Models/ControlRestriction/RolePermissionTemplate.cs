using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHEndevour.Models.ControlRestriction
{
    public class RolePermissionTemplate
    {
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public RoleModel? Role { get; set; }

        public string ControlName { get; set; } = string.Empty;
        public string ViewName { get; set; } = string.Empty;

        public bool IsVisible { get; set; } = true;
        public bool IsEnabled { get; set; } = true;


    }
}
