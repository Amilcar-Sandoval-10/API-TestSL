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
    public class InventarioController : ApiController
    {
        // GET api/<controller>
        public List<Inventario> Get()
        {
            return InventarioData.Listar();
        }

        //* // GET api/<controller>
        public Inventario Get(int id)
        {
            return InventarioData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Inventario oInventario)
        {
            return InventarioData.Registrar(oInventario);
        }

        // PUT api/<controller>
        public bool Put([FromBody] Inventario oInventario)
        {
            return InventarioData.Modificar(oInventario);
        }

        // DELETE api/<controller>
        public bool Delete(int id)
        {
            return ClienteData.Eliminar(id);
        }
    }
}