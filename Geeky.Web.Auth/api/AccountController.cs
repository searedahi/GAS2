using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geeky.Web.Auth.Models.AccountViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geeky.Web.Auth.api
{
    /// <summary>
    /// Authentication and authorization endpoint for applications.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {

        public IActionResult Login(LoginViewModel model, string returnUrl = null)
        {

            return Ok(model);
        }
    }
}