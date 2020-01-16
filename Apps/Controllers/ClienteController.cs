using data_api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        public ClienteController()
        {
            cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url + "api/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        HttpClient cliente;
        string url = "http://localhost:51720/".Trim();
        // GET: Login



        [HttpPost]
        public async Task<ActionResult> GuardarCliente(string nombre, string apellido,string cc)
        {
            // consumo web api y valido login
            HttpResponseMessage objReponsiveMensaje = await cliente.GetAsync(url + "api/ClienteAPI/GuardarCliente/" + nombre + "~" + apellido+"~"+cc);
            if (objReponsiveMensaje.IsSuccessStatusCode)
            {
                string result = objReponsiveMensaje.Content.ReadAsStringAsync().Result;
                string userObj = JsonConvert.DeserializeObject<string>(result);

                //ViewBag.UserAutenticado = false;
                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }
        }

        public async Task<ActionResult> Lista()
        {
            // consumo web api y valido login
            HttpResponseMessage objReponsiveMensaje = await cliente.GetAsync(url + "api/ClienteAPI/AllCliente/nada");
            if (objReponsiveMensaje.IsSuccessStatusCode)
            {
                string result = objReponsiveMensaje.Content.ReadAsStringAsync().Result;
                List<Cliente> cliobj = JsonConvert.DeserializeObject<List<Cliente>>(result);

                //ViewBag.UserAutenticado = false;
                return View(cliobj);
            }
            else
            {
                return View(new Cliente());
            }
        }
    }
}