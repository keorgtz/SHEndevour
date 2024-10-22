using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SHEndevour.Models.Sales
{
    public class BusisnessPartnerModel : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string? PartnerKey { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreComercial { get; set; }
        public string? Direccion { get; set; }
        public string? CodigoPostal { get; set; }
        public string? RegimenFiscal { get; set; }
        public string? PartnerRFC { get; set; }
        public GeoOriginModel? GeoOrigin { get; set; }
        public string? Observaciones { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }


    }

}
