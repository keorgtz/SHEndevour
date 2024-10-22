using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHEndevour.Models.Sales
{
    public class PaymentModel : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public string? PaymentKey { get; set; }
        public string? Descripcion { get; set; }
        public string? CuentaContable { get; set; }
        public string? ClaveSat { get; set; }

    }
}
  