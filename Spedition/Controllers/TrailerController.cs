using Microsoft.AspNetCore.Mvc;
using Spedition.Data;
using Spedition.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spedition.Controllers
{
    public class TrailerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TrailerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Trailer> objList = _db.Trailer;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Trailer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Trailer.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var obj = _db.Trailer.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Trailer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Trailer.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var obj = _db.Trailer.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Trailer.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Trailer.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
