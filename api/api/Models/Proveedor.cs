using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Ciudad { get; set; }
    }
}