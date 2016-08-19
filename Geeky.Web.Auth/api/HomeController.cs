using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geeky.Web.Auth.api
{
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : Controller
    {
        public IActionResult Get()
        {
            return Ok("Home api controller");
        }
    }
}