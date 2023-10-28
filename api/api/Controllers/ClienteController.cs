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
    public class ClienteController : ApiController
    {
        // GET api/<controller>
        public List<Cliente> Get()
        {
            return ClienteData.Listar();
        }

        //* // GET api/<controller>
        public Cliente Get(int id)
        {
            return ClienteData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Cliente ocliente)
        {
            return ClienteData.Registrar(ocliente);
        }

        // PUT api/<controller>
        public bool Put([FromBody] Cliente ocliente)
        {
            return ClienteData.Modificar(ocliente);
        }

        // DELETE api/<controller>
        public bool Delete(int id)
        {
            return ClienteData.Eliminar(id);
        }

    }
}
