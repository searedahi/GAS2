using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Geeky.Swimteam.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;

namespace Geeky.Swimteam.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<SwimteamRole> _roleManager;
        private readonly ILogger _logger;

        public RolesController(
        RoleManager<SwimteamRole> roleManager,
        ILoggerFactory loggerFactory)
        {
            _roleManager = roleManager;
            _logger = loggerFactory.CreateLogger<RolesController>();
        }

        // GET: Roles
        public IActionResult Index(RolesMessageId? message = null)
        {
            ViewData["StatusMessage"] =
                message == RolesMessageId.ConcurrecyError ? "That role has has been changed already."
                : "";

            var roles = _roleManager.Roles;
            var listr = new List<SwimteamRole>();

            if (roles != null)
            {
                listr = roles.ToList();
            }

            return View(listr);
        }

        // GET: Roles/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var SwimteamRole = _roleManager.Roles.Single(m => m.Id == id);
            if (SwimteamRole == null)
            {
                return HttpNotFound();
            }

            return View(SwimteamRole);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SwimteamRole SwimteamRole)
        {
            if (ModelState.IsValid)
            {
                SwimteamRole.Id = Guid.NewGuid().ToString();
                SwimteamRole.ConcurrencyStamp = Guid.NewGuid().ToString();
                var res = _roleManager.CreateAsync(SwimteamRole);

                if (res.Result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                return View();
            }
            return View(SwimteamRole);
        }

        // GET: Roles/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var SwimteamRole = _roleManager.Roles.Single(m => m.Id == id);
            if (SwimteamRole == null)
            {
                return HttpNotFound();
            }
            return View(SwimteamRole);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SwimteamRole SwimteamRole)
        {
            if (ModelState.IsValid)
            {
                var res = _roleManager.UpdateAsync(SwimteamRole).Result;
                if (res.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", new { Message = RolesMessageId.ConcurrecyError });
            }
            return View();
        }

        // GET: Roles/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var SwimteamRole = _roleManager.Roles.Single(m => m.Id == id);
            if (SwimteamRole == null)
            {
                return HttpNotFound();
            }

            return View(SwimteamRole);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var SwimteamRole = _roleManager.Roles.Single(m => m.Id == id);
            _roleManager.DeleteAsync(SwimteamRole);
            return RedirectToAction("Index");
        }



        public IActionResult Get()
        {
            return new JsonResult(_roleManager.Roles.ToList());
        }


    }

    public enum RolesMessageId
    {
        ConcurrecyError,
    }

}
