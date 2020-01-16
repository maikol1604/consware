using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Main()
        {
            HttpCookie ValidateCookie = Request.Cookies["CookieUser"];
            if (ValidateCookie != null)
            {
                string User_name = ValidateCookie["user"].ToString();
                ViewBag.Validate = User_name;
                return View();
            }
            else
            {
                ViewBag.Validate = true;
               return RedirectToAction("Login", "Login");
            }
            
        }

        public ActionResult Minor()
        {
            return View();
        }
    }
}