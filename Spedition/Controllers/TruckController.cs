using Microsoft.AspNetCore.Mvc;
using Spedition.Data;
using Spedition.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spedition.Controllers
{
    public class TruckController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TruckController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Truck> objList = _db.Truck;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Truck obj)
        {
            if (ModelState.IsValid)
            {
                _db.Truck.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id==0)
            {
                return NotFound();
            }
            var obj = _db.Truck.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Truck obj)
        {
            if (ModelState.IsValid)
            {
                _db.Truck.Update(obj);
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
            var obj = _db.Truck.Find(id);
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
            var obj = _db.Truck.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Truck.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
