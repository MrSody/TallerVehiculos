using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerVehiculos.Data;
using TallerVehiculos.Models;

namespace TallerVehiculos.Controllers
{
    public class SedesController : Controller
    {
        private readonly AplicationDbContext _context;

        public SedesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sedes
        public async Task<IActionResult> Index()
        {
              return View(await _context.sedes.ToListAsync());
        }

        // GET: Sedes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sedes == null)
            {
                return NotFound();
            }

            var sedes = await _context.sedes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sedes == null)
            {
                return NotFound();
            }

            return View(sedes);
        }

        // GET: Sedes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombre,direccion")] Sedes sedes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sedes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sedes);
        }

        // GET: Sedes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sedes == null)
            {
                return NotFound();
            }

            var sedes = await _context.sedes.FindAsync(id);
            if (sedes == null)
            {
                return NotFound();
            }
            return View(sedes);
        }

        // POST: Sedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre,direccion")] Sedes sedes)
        {
            if (id != sedes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sedes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SedesExists(sedes.Id))
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
            return View(sedes);
        }

        // GET: Sedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sedes == null)
            {
                return NotFound();
            }

            var sedes = await _context.sedes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sedes == null)
            {
                return NotFound();
            }

            return View(sedes);
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sedes == null)
            {
                return Problem("Entity set 'AplicationDbContext.sedes'  is null.");
            }
            var sedes = await _context.sedes.FindAsync(id);
            if (sedes != null)
            {
                _context.sedes.Remove(sedes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SedesExists(int id)
        {
          return _context.sedes.Any(e => e.Id == id);
        }
    }
}
