using data_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace data_api.Controllers
{
    public class LoginAPIController : ApiController
    {
        private DAL DALObj = new DAL();
        private aut_user user;
        public IHttpActionResult GetUser(string id) {

            user = new aut_user();
            user= DALObj.GetUser(id.Split('~')[0], id.Split('~')[1]);
            if(user.id!=0)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
            

        }
    }
}
