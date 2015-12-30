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
    [Route("api/Roles")]
    public class RolesController : Controller
    {
        private readonly RoleManager<GeekyRole> _roleManager;
        private readonly ILogger _logger;

        public RolesController(
        RoleManager<GeekyRole> roleManager,
        ILoggerFactory loggerFactory)
        {
            _roleManager = roleManager;
            _logger = loggerFactory.CreateLogger<Controllers.RolesController>();
        }

        // GET: api/Roles
        [HttpGet]
        public IEnumerable<GeekyRole> GetRole()
        {
            return _roleManager.Roles.ToList();
        }

        // GET: api/Roles/5
        [HttpGet("{id}", Name = "GetRole")]
        public IActionResult GetRole([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            GeekyRole geekyRole = _roleManager.Roles.Single(m => m.Id == id);

            if (geekyRole == null)
            {
                return HttpNotFound();
            }

            return Ok(geekyRole);
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public IActionResult PutRole(string id, [FromBody] GeekyRole geekyRole)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != geekyRole.Id)
            {
                return HttpBadRequest();
            }


            try
            {
                var res = _roleManager.UpdateAsync(geekyRole);
                return !res.Result.Succeeded ? new HttpStatusCodeResult(StatusCodes.Status500InternalServerError) : Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: api/Roles
        [HttpPost]
        public IActionResult PostRole([FromBody] GeekyRole geekyRole)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            var res = _roleManager.CreateAsync(geekyRole);

            if (!res.Result.Succeeded)
            {

            }

            return CreatedAtRoute("GetGeekyRole", new { id = geekyRole.Id }, geekyRole);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            GeekyRole geekyRole = _roleManager.Roles.Single(m => m.Id == id);
            if (geekyRole == null)
            {
                return HttpNotFound();
            }

            var res = _roleManager.DeleteAsync(geekyRole);

            if (!res.Result.Succeeded)
            {
                return Content(res.Result.Errors.FirstOrDefault().Description);
            }

            return Ok(geekyRole);
        }
    }
}