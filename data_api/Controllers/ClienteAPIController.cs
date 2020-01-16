using data_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace data_api.Controllers
{
    public class ClienteAPIController : ApiController
    {
        private Cliente cli;
        private Producto pro;
        private DAL dalObj;

        [HttpGet]
        public IHttpActionResult GuardarCliente(string id)
        {
            dalObj = new DAL();
            cli = new Cliente();
            cli.Nombre = id.Split('~')[0].ToString();
            cli.Apellido = id.Split('~')[1].ToString();
            cli.CC = id.Split('~')[2].ToString();
            cli.estado = "ACT";
            return Ok(dalObj.GuardarCliente(cli));

            //else
            //{
            //    return NotFound();
            //}


        }

        [HttpGet]
        public IHttpActionResult AllCliente(string id)
        {
            dalObj = new DAL();


                return Ok(dalObj.allCliente());



            //else
            //{
            //    return NotFound();
            //}


        }
    }
}
