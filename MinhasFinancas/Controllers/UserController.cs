using MinhasFinancas.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MinhasFinancas.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [Route("Authenticate")]
        [HttpPost]
        public Usuario Authenticate([FromBody]JObject data)
        {
            var user = new Usuario() { Email = data["username"].ToString(), Token = "12345" };
            return user;
        }


    }
}