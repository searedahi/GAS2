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
    public class UsersController : Controller
    {
        private readonly UserManager<GeekyUser> _userManager;
        private readonly ILogger _logger;

        public UsersController(
        UserManager<GeekyUser> userManager,
        ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<UsersController>();
        }

        // GET: Users
        public IActionResult Index(UsersMessageId? message = null)
        {
            ViewData["StatusMessage"] =
                message == UsersMessageId.ConcurrecyError ? "That User has has been changed already."
                : "";

            var Users = _userManager.Users;
            var listr = new List<GeekyUser>();

            if (Users != null)
            {
                listr = Users.ToList();
            }

            return View(listr);
        }

        // GET: Users/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var geekyUser = _userManager.Users.Single(m => m.Id == id);
            if (geekyUser == null)
            {
                return HttpNotFound();
            }

            return View(geekyUser);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GeekyUser geekyUser)
        {
            if (ModelState.IsValid)
            {
                geekyUser.Id = Guid.NewGuid().ToString();
                geekyUser.ConcurrencyStamp = Guid.NewGuid().ToString();
                var res = _userManager.CreateAsync(geekyUser);

                if (res.Result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                return View();
            }
            return View(geekyUser);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var geekyUser = _userManager.Users.Single(m => m.Id == id);
            if (geekyUser == null)
            {
                return HttpNotFound();
            }
            return View(geekyUser);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GeekyUser geekyUser)
        {
            if (ModelState.IsValid)
            {
                var res = _userManager.UpdateAsync(geekyUser).Result;
                if (res.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", new { Message = UsersMessageId.ConcurrecyError });
            }
            return View();
        }

        // GET: Users/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var geekyUser = _userManager.Users.Single(m => m.Id == id);
            if (geekyUser == null)
            {
                return HttpNotFound();
            }

            return View(geekyUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var geekyUser = _userManager.Users.Single(m => m.Id == id);
            _userManager.DeleteAsync(geekyUser);
            return RedirectToAction("Index");
        }
    }

    public enum UsersMessageId
    {
        ConcurrecyError,
    }
}
