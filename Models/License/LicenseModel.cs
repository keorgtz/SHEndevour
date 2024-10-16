using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHEndevour.Models.License
{
    public class LicenseModel
    {
        public int Id { get; set; } // Llave primaria
        public string? NombreNegocio { get; set; }
        public string? NombreCliente { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreComercial { get; set; }
        public string? RegimenFiscal { get; set; }
        public string? RFC { get; set; }
        public string? DomicilioCompleto { get; set; }
        public string? CodigoPostal { get; set; }


        public string? CodigoInstalacion { get; set; }
        public string? ClaveInstalacion { get; set; }
        public DateTime FechaLicencia { get; set; }
        public string? ClaveLicencia { get; set; }
    }

}
