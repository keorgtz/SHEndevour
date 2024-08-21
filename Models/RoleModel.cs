using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHEndevour.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; } // Puede ser "Admin", "Manager", etc.
        public int Level { get; set; } // Nivel del 1 al 5
    }
}
