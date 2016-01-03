using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Geeky.Master.ViewModels.Account;
using Microsoft.AspNet.Mvc;
using Geeky.Models.Base;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;
using GeekyUser = Geeky.Master.Models.GeekyUser;

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
                message == UsersMessageId.ConcurrecyError ? "That User has already changed somehow..."
                : "";

            var users = _userManager.Users;
            var listr = new List<GeekyUser>();

            foreach (var user in users)
            {
                var profilePicUrl = "";

                if (user.Profiles == null || !user.Profiles.Any())
                {
                    user.Profiles = new List<UserProfile>();
                    user.Profiles.Add(new UserProfile
                    {
                        ProfileImage =
                            new GImage
                            {
                                DataUrl = "https://cdn3.iconfinder.com/data/icons/security-and-protection/512/detective_agent_spy_thief_flat_icon-512.png",
                                ThumbnailUrl = "https://cdn3.iconfinder.com/data/icons/security-and-protection/512/detective_agent_spy_thief_flat_icon-512.png"
                            }
                    });
                }
                else
                {
                    if (user.Profiles.FirstOrDefault().ProfileImage == null)
                    {
                        user.Profiles.FirstOrDefault().ProfileImage = new GImage
                        {
                            DataUrl = "https://blog.etsy.com/en/files/2013/05/marbles-etsy.jpg",
                            ThumbnailUrl = "https://blog.etsy.com/en/files/2013/05/marbles-etsy.jpg"
                        };
                    }
                }
            }

            if (users != null)
            {
                listr = users.ToList();
                //for (int i = 0; i < 1000; i++)
                //{
                //    listr.AddRange(users.ToList());
                //}
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
        public IActionResult Create(GeekyUserCreateViewModel geekyCreateModel)
        {
            if (ModelState.IsValid)
            {
                var geekyUser = new GeekyUser
                {
                    Id = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    UserName = geekyCreateModel.UserName,
                    Email = geekyCreateModel.Email,
                    PhoneNumber = geekyCreateModel.PhoneNumber
                };


                var res = _userManager.CreateAsync(geekyUser);

                if (res.Result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                return View();
            }
            return View(geekyCreateModel);
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

            //Mapper.CreateMap<GeekyUserViewModel, GeekyUser>();
            //Mapper.Map(geekyUser, geekyView);


            var geekyView = new GeekyUserEditViewModel
            {
                Id = geekyUser.Id,
                ConcurrencyStamp = geekyUser.ConcurrencyStamp,
                UserName = geekyUser.UserName,
                Email = geekyUser.Email,
                PhoneNumber = geekyUser.PhoneNumber
            };

            return View(geekyView);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GeekyUserEditViewModel geekyUserModel)
        {
            if (ModelState.IsValid)
            {
                var geekyUser = _userManager.Users.Single(u => u.Id == geekyUserModel.Id);
                geekyUser.ConcurrencyStamp = geekyUserModel.ConcurrencyStamp;
                geekyUser.UserName = geekyUserModel.UserName;
                geekyUser.Email = geekyUserModel.Email;
                geekyUser.PhoneNumber = geekyUserModel.PhoneNumber;

                //Mapper.CreateMap<GeekyUser, GeekyUserViewModel>();
                //Mapper.Map(geekyUserModel, geekyUser);


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
            var res = _userManager.DeleteAsync(geekyUser).Result;
            return RedirectToAction("Index");
        }
    }

    public enum UsersMessageId
    {
        ConcurrecyError,
    }
}
