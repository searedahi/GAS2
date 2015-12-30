using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Geeky.Master.Models;
using Geeky.Master.Services;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;

namespace Geeky.Master.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly UserManager<GeekyUser> _userManager;
        private readonly RoleManager<GeekyRole> _roleManager;

        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;

        public RolesController(
        UserManager<GeekyUser> userManager,
        RoleManager<GeekyRole> roleManager,
        IEmailSender emailSender,
        ISmsSender smsSender,
        ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<RolesController>();
        }

        // GET: GeekyRoles
        public IActionResult Index(RolesMessageId? message = null)
        {
            ViewData["StatusMessage"] =
                message == RolesMessageId.ConcurrecyError ? "That record has been changed."
                : "";

            var roles = _roleManager.Roles;
            var listr = new List<GeekyRole>();

            if (roles != null)
            {
                listr = roles.ToList();
            }

            return View(listr);
        }

        // GET: GeekyRoles/Details/5
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

        // GET: GeekyRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeekyRoles/Create
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

        // GET: GeekyRoles/Edit/5
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

        // POST: GeekyRoles/Edit/5
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

        // GET: GeekyRoles/Delete/5
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

        // POST: GeekyRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var geekyRole = _roleManager.Roles.Single(m => m.Id == id);
            _roleManager.DeleteAsync(geekyRole);
            return RedirectToAction("Index");
        }
    }

    public enum RolesMessageId
    {
        ConcurrecyError,
    }
}
