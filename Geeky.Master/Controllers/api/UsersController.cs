using System;
using System.Linq;
using System.Collections.Generic;
using Geeky.Master.Models;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace Geeky.Master.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly UserManager<GeekyUser> _userManager;
        private readonly ILogger _logger;

        public UsersController(
        UserManager<GeekyUser> userManager,
        ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<GeekyUser> GetUser()
        {
            return _userManager.Users.ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            GeekyUser geekyUser = _userManager.Users.Single(m => m.Id == id);

            if (geekyUser == null)
            {
                return HttpNotFound();
            }

            return Ok(geekyUser);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutUser(string id, [FromBody] GeekyUser geekyUser)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != geekyUser.Id)
            {
                return HttpBadRequest();
            }


            try
            {
                var res = _userManager.UpdateAsync(geekyUser);
                return !res.Result.Succeeded ? new HttpStatusCodeResult(StatusCodes.Status500InternalServerError) : Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult PostUser([FromBody] GeekyUser geekyUser)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            var res = _userManager.CreateAsync(geekyUser);

            if (!res.Result.Succeeded)
            {

            }

            return CreatedAtRoute("GetGeekyUser", new { id = geekyUser.Id }, geekyUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            GeekyUser geekyUser = _userManager.Users.Single(m => m.Id == id);
            if (geekyUser == null)
            {
                return HttpNotFound();
            }

            var res = _userManager.DeleteAsync(geekyUser);

            if (!res.Result.Succeeded)
            {
                return Content(res.Result.Errors.FirstOrDefault().Description);
            }

            return Ok(geekyUser);
        }
    }
}