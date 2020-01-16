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
    public class LoginController : Controller
    {
        public LoginController()
        {
            cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url + "api/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        HttpClient cliente;
        string url= "http://localhost:51720/".Trim();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<ActionResult> ValidteLogin(string user,string pswrd)
        {
            // consumo web api y valido login
            HttpResponseMessage objReponsiveMensaje = await cliente.GetAsync(url + "api/LoginAPI/GetUser/" + user + "~" + pswrd);
            if (objReponsiveMensaje.IsSuccessStatusCode)
            {
                string result = objReponsiveMensaje.Content.ReadAsStringAsync().Result;
                aut_user userObj = JsonConvert.DeserializeObject<aut_user>(result);

                HttpCookie CookieUser = new HttpCookie("CookieUser");
                CookieUser["user"] = userObj.user_aut;
                CookieUser["pass"] = userObj.password_aut;
                CookieUser.Expires.Add(new TimeSpan(1, 0, 0));
                Response.Cookies.Add(CookieUser);

                //ViewBag.UserAutenticado = false;
                return RedirectToAction("Main", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        //leer cookies


    }
}