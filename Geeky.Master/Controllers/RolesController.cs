using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Geeky.Master.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;

namespace Geeky.Master.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly RoleManager<GeekyRole> _roleManager;
        private readonly ILogger _logger;

        public RolesController(
        RoleManager<GeekyRole> roleManager,
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
            var listr = new List<GeekyRole>();

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

            var geekyRole = _roleManager.Roles.Single(m => m.Id == id);
            if (geekyRole == null)
            {
                return HttpNotFound();
            }

            return View(geekyRole);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GeekyRole geekyRole)
        {
            if (ModelState.IsValid)
            {
                geekyRole.Id = Guid.NewGuid().ToString();
                geekyRole.ConcurrencyStamp = Guid.NewGuid().ToString();
                var res = _roleManager.CreateAsync(geekyRole);

                if (res.Result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                return View();
            }
            return View(geekyRole);
        }

        // GET: Roles/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var geekyRole = _roleManager.Roles.Single(m => m.Id == id);
            if (geekyRole == null)
            {
                return HttpNotFound();
            }
            return View(geekyRole);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GeekyRole geekyRole)
        {
            if (ModelState.IsValid)
            {
                var res = _roleManager.UpdateAsync(geekyRole).Result;
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

            var geekyRole = _roleManager.Roles.Single(m => m.Id == id);
            if (geekyRole == null)
            {
                return HttpNotFound();
            }

            return View(geekyRole);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var geekyRole = _roleManager.Roles.Single(m => m.Id == id);
            _roleManager.DeleteAsync(geekyRole);
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
