using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHEndevour.Models.Sales
{
    public class IncomeModel : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public string? IncomeKey { get; set; }
        public string? Descripcion { get; set; }
        public int IVA { get; set; }
        public int ISH { get; set; }

        public string? CuentaContable { get; set; }
        public string? ClaveSat { get; set; }
        public string? UnidadSat { get; set; }
        public string? ObjetoImpuesto { get; set; }

    }
}
