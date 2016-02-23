using System;
using System.Collections.Generic;
using System.Linq;
using Geeky.Swimteam.Models;
using Microsoft.AspNet.Mvc;
using Geeky.Swimteam.Services;
using Geeky.Swimteam.ViewModels.Practice;
using Microsoft.Extensions.Logging;


namespace Geeky.Swimteam.Controllers
{
    public class PracticeController : Controller
    {
        private readonly IPracticeService _practiceService;
        private readonly ILogger _logger;

        public PracticeController(
        IPracticeService practiceService,
        ILoggerFactory loggerFactory)
        {
            _practiceService = practiceService;
            _logger = loggerFactory.CreateLogger<PracticeController>();
        }

        // GET: Practice
        public IActionResult Index(PracticesMessageId? message = null)
        {
            ViewData["StatusMessage"] =
                message == PracticesMessageId.ConcurrecyError ? "That practice has been changed already."
                : "";

            var domainPractices = _practiceService.Practices;
            var viewPractices = new List<PracticeViewModel>();

            if (domainPractices != null)
            {
                viewPractices = domainPractices.Select(dp => _practiceService.CastToViewModel(dp)).ToList();
            }

            return View(viewPractices.OrderBy(p => p.PracticeDate).ThenBy(p => p.Begins).ToList());
        }

        // GET: Practice/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var practice = _practiceService.Practices.Single(p => p.Id.ToString().Equals(id));
            if (practice == null)
            {
                return HttpNotFound();
            }

            return View(practice);
        }

        // GET: Practice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Practice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PracticeViewModel practice)
        {
            if (ModelState.IsValid)
            {
                practice.Id = Guid.NewGuid();
                practice.ConcurrencyStamp = Guid.NewGuid().ToString();
                var res = _practiceService.Create(practice);

                if (res)
                {
                    return RedirectToAction("Index");

                }
                return View();
            }
            return View(practice);
        }

        // GET: Practice/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var practice = _practiceService.Practices.Single(m => m.Id.ToString().Equals(id));
            if (practice == null)
            {
                return HttpNotFound();
            }

            var vm = _practiceService.CastToViewModel(practice);

            return View(vm);
        }

        // POST: Practice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PracticeViewModel practice)
        {
            if (ModelState.IsValid)
            {
                var res = _practiceService.Update(practice);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", new { Message = RolesMessageId.ConcurrecyError });
            }
            return View();
        }

        // GET: Practice/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var practice = _practiceService.Practices.Single(m => m.Id.ToString().Equals(id));
            if (practice == null)
            {
                return HttpNotFound();
            }

            return View(practice);
        }

        // POST: Practice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var practice = _practiceService.Practices.Single(m => m.Id.ToString().Equals(id));
            _practiceService.Delete(practice);
            return RedirectToAction("Index");
        }



        public IActionResult Get()
        {
            return new JsonResult(_practiceService.Practices.ToList());
        }


    }

    public enum PracticesMessageId
    {
        ConcurrecyError,
    }

}
