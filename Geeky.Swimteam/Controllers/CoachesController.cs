using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Geeky.Swimteam.Contexts;
using Geeky.Swimteam.Models;

namespace Geeky.Swimteam.Controllers
{
    public class CoachesController : Controller
    {
        private SwimteamDbContext _context;

        public CoachesController(SwimteamDbContext context)
        {
            _context = context;    
        }

        // GET: Coaches
        public IActionResult Index()
        {
            return View(_context.Coaches.ToList());
        }

        // GET: Coaches/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Coach coach = _context.Coaches.Single(m => m.Id == id);
            if (coach == null)
            {
                return HttpNotFound();
            }

            return View(coach);
        }

        // GET: Coaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coaches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Coach coach)
        {
            if (ModelState.IsValid)
            {
                _context.Coaches.Add(coach);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coach);
        }

        // GET: Coaches/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Coach coach = _context.Coaches.Single(m => m.Id == id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // POST: Coaches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Coach coach)
        {
            if (ModelState.IsValid)
            {
                _context.Update(coach);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coach);
        }

        // GET: Coaches/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Coach coach = _context.Coaches.Single(m => m.Id == id);
            if (coach == null)
            {
                return HttpNotFound();
            }

            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            Coach coach = _context.Coaches.Single(m => m.Id == id);
            _context.Coaches.Remove(coach);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
