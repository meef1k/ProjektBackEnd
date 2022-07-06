using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spedition.Data;
using Spedition.Models;

namespace Spedition.Controllers
{
    public class SpeditionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpeditionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Speditions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Speditions.Include(s => s.Driver).Include(s => s.Trailer).Include(s => s.Truck);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Speditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speditions = await _context.Speditions
                .Include(s => s.Driver)
                .Include(s => s.Trailer)
                .Include(s => s.Truck)
                .FirstOrDefaultAsync(m => m.id_spedition == id);
            if (speditions == null)
            {
                return NotFound();
            }

            return View(speditions);
        }

        // GET: Speditions/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Driver, "id_driver", "driver_name");
            ViewData["TrailerId"] = new SelectList(_context.Trailer, "id_trailer", "trailer_number");
            ViewData["TruckId"] = new SelectList(_context.Truck, "id_truck", "truck_number");
            return View();
        }

        // POST: Speditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_spedition,start_place,end_place,TruckId,TrailerId,DriverId")] Speditions speditions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speditions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Driver, "id_driver", "driver_name", speditions.DriverId);
            ViewData["TrailerId"] = new SelectList(_context.Trailer, "id_trailer", "trailer_number", speditions.TrailerId);
            ViewData["TruckId"] = new SelectList(_context.Truck, "id_truck", "truck_number", speditions.TruckId);
            return View(speditions);
        }

        // GET: Speditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speditions = await _context.Speditions.FindAsync(id);
            if (speditions == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Driver, "id_driver", "driver_name", speditions.DriverId);
            ViewData["TrailerId"] = new SelectList(_context.Trailer, "id_trailer", "trailer_number", speditions.TrailerId);
            ViewData["TruckId"] = new SelectList(_context.Truck, "id_truck", "truck_number", speditions.TruckId);
            return View(speditions);
        }

        // POST: Speditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_spedition,start_place,end_place,TruckId,TrailerId,DriverId")] Speditions speditions)
        {
            if (id != speditions.id_spedition)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speditions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeditionsExists(speditions.id_spedition))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Driver, "id_driver", "driver_name", speditions.DriverId);
            ViewData["TrailerId"] = new SelectList(_context.Trailer, "id_trailer", "trailer_number", speditions.TrailerId);
            ViewData["TruckId"] = new SelectList(_context.Truck, "id_truck", "truck_number", speditions.TruckId);
            return View(speditions);
        }

        // GET: Speditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speditions = await _context.Speditions
                .Include(s => s.Driver)
                .Include(s => s.Trailer)
                .Include(s => s.Truck)
                .FirstOrDefaultAsync(m => m.id_spedition == id);
            if (speditions == null)
            {
                return NotFound();
            }

            return View(speditions);
        }

        // POST: Speditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speditions = await _context.Speditions.FindAsync(id);
            _context.Speditions.Remove(speditions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeditionsExists(int id)
        {
            return _context.Speditions.Any(e => e.id_spedition == id);
        }
    }
}
