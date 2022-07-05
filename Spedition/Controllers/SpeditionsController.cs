using Microsoft.AspNetCore.Mvc;
using Spedition.Data;
using Spedition.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spedition.Controllers
{
    public class SpeditionsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SpeditionsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Speditions> objList = _db.Speditions;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Speditions obj)
        {
            if (ModelState.IsValid)
            {
                _db.Speditions.Add(obj);
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
            var obj = _db.Speditions.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Speditions obj)
        {
            if (ModelState.IsValid)
            {
                _db.Speditions.Update(obj);
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
            var obj = _db.Speditions.Find(id);
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
            var obj = _db.Speditions.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Speditions.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
