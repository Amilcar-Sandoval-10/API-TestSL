using api.Data;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class ProveedorController : ApiController
    {

        // GET api/<controller>
        public List<Proveedor> Get()
        {
            return ProveedorData.Listar();
        }

        //* // GET api/<controller>
        public Proveedor Get(int id)
        {
            return ProveedorData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Proveedor oProveedor)
        {
            return ProveedorData.Registrar(oProveedor);
        }

        // PUT api/<controller>
        public bool Put([FromBody] Proveedor oProveedor)
        {
            return ProveedorData.Modificar(oProveedor);
        }

        // DELETE api/<controller>
        public bool Delete(int id)
        {
            return ProveedorData.Eliminar(id);
        }

    }
}