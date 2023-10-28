using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Inventario
    {
        public int IdInventario { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Stock { get; set; }
        public string Proveedor { get; set; }
    }
}