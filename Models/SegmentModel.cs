using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHEndevour.Models
{
    public class SegmentModel : AuditableEntity
    {
        public int Id { get; set; } // Llave primaria
        public string? SegmentKey { get; set; }
        public string? Description { get; set; }

    }
}
