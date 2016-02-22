using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Geeky.Swimteam.Models;
using Geeky.Swimteam.ViewModels.Account;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;


namespace Geeky.Swimteam.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<SwimteamUser> _userManager;
        private readonly ILogger _logger;

        public UsersController(
        UserManager<SwimteamUser> userManager,
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

            var users = _userManager.Users.ToList();
            var listr = new List<SwimteamUser>();

            //setup some random lego pics for users without images on file.
            var dirPath = "images/LegoPeeps/250x250/";

            var usedFiles = new List<string>();
            var picsAvail = PicsAvailable(dirPath);

            //if (users != null && users.Count > 0)
            //{
            //   for (int i = 0; i < 10; i++)
            //    {
            //        users.AddRange(users.ToList());
            //    }
            //}

            foreach (var user in users)
            {
                if (user.Profiles == null || !user.Profiles.Any())
                {
                    user.Profiles = new List<UserProfile>();
                }

                var userPro = user.Profiles.FirstOrDefault();

                if (user.Profiles.FirstOrDefault() == null)
                {
                    userPro = new UserProfile();
                    user.Profiles.Add(userPro);
                }

                if (!string.IsNullOrEmpty(userPro.ProfileImage?.DataUrl)) continue;

                // Setting up placeholder images randomly.
                if (UsedAllPics(picsAvail, usedFiles)) { usedFiles.Clear(); }
                var profilePicUrl = ProfilePicUrl(dirPath, usedFiles);

                userPro.ProfileImage = new GImage
                {
                    DataUrl = profilePicUrl,
                    ThumbnailUrl = profilePicUrl
                };
                usedFiles.Add(profilePicUrl);
            }

            if (users != null)
            {
                listr = users.ToList();
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
        public IActionResult Create(SwimteamUserCreateViewModel geekyCreateModel)
        {
            if (ModelState.IsValid)
            {
                var geekyUser = new SwimteamUser
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


            var geekyView = new SwimteamUserEditViewModel
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
        public IActionResult Edit(SwimteamUserEditViewModel geekyUserModel)
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


        private string ProfilePicUrl(string dirPath, ICollection<string> usedFiles)
        {
            var rnd = new Random();
            var dir = new DirectoryInfo(dirPath);
            var files = dir.GetFiles();

            var picIndex = rnd.Next(files.Length);
            var file = files[picIndex];
            var profilePicUrl = $"{dirPath}{file.Name}";

            // dont repeat used images
            while (usedFiles.Contains(profilePicUrl))
            {
                picIndex = rnd.Next(files.Length);
                file = files[picIndex];
                profilePicUrl = $"{dirPath}{file.Name}";
            }

            return profilePicUrl;
        }
        private int PicsAvailable(string dirPath)
        {
            var dir = new DirectoryInfo(dirPath);
            var files = dir.GetFiles();
            return files.Length;
        }
        private bool UsedAllPics(int picsInDir, ICollection<string> usedFiles)
        {
            return usedFiles.Count() >= picsInDir;
        }


    }

    public enum UsersMessageId
    {
        ConcurrecyError,
    }

}
