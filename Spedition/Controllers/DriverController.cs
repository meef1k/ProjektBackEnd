using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spedition.Data;
using Spedition.Models;
using Spedition.Static;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spedition.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class DriverController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DriverController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Driver> objList = _db.Driver;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Driver obj)
        {
            if (ModelState.IsValid)
            {
                _db.Driver.Add(obj);
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
            var obj = _db.Driver.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Driver obj)
        {
            if (ModelState.IsValid)
            {
                _db.Driver.Update(obj);
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
            var obj = _db.Driver.Find(id);
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
            var obj = _db.Driver.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Driver.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
