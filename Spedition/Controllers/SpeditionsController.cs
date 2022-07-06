using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spedition.Data;
using Spedition.Models;
using Spedition.Static;

namespace Spedition.Controllers
{
    [Authorize]
    public class SpeditionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpeditionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Speditions.Include(s => s.Driver).Include(s => s.Trailer).Include(s => s.Truck);
            return View(await applicationDbContext.ToListAsync());
        }

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
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Driver, "id_driver", "driver_name");
            ViewData["TrailerId"] = new SelectList(_context.Trailer, "id_trailer", "trailer_number");
            ViewData["TruckId"] = new SelectList(_context.Truck, "id_truck", "truck_number");
            return View();
        }

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
        [Authorize(Roles = UserRoles.Admin)]
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

        [Authorize(Roles = UserRoles.Admin)]
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
