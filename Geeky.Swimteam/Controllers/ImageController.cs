using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Geeky.Swimteam.Contexts;
using Geeky.Swimteam.Models;

namespace Geeky.Swimteam.Controllers
{
    public class ImageController : Controller
    {
        private SwimteamDbContext _context;

        public ImageController(SwimteamDbContext context)
        {
            _context = context;    
        }

        // GET: Image
        public IActionResult Index()
        {
            return View(_context.Images.ToList());
        }

        // GET: Image/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            GImage gImage = _context.Images.Single(m => m.Id == id);
            if (gImage == null)
            {
                return HttpNotFound();
            }

            return View(gImage);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GImage gImage)
        {
            if (ModelState.IsValid)
            {
                _context.Images.Add(gImage);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gImage);
        }

        // GET: Image/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            GImage gImage = _context.Images.Single(m => m.Id == id);
            if (gImage == null)
            {
                return HttpNotFound();
            }
            return View(gImage);
        }

        // POST: Image/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GImage gImage)
        {
            if (ModelState.IsValid)
            {
                _context.Update(gImage);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gImage);
        }

        // GET: Image/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            GImage gImage = _context.Images.Single(m => m.Id == id);
            if (gImage == null)
            {
                return HttpNotFound();
            }

            return View(gImage);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid? id)
        {
            GImage gImage = _context.Images.Single(m => m.Id == id);
            _context.Images.Remove(gImage);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
