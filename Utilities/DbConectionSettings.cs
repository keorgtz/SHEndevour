using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHEndevour.Utilities
{
    internal class DbConectionSettings
    {

        public string Server { get; set; } = "SQLEXPRESS";
        public string Database { get; set; } = "endevour_db";
        public string UserId { get; set; } = "sa";
        public string Password { get; set; } = "InfoHotel01";
        public bool TrustServerCertificate { get; set; } = true;

        public string GetConnectionString()
        {
            return $"Server=.\\{Server};Database={Database};User Id={UserId};Password={Password};TrustServerCertificate={TrustServerCertificate};";
        }

    }
}
