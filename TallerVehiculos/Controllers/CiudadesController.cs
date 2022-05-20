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
    public class CiudadesController : Controller
    {
        private readonly AplicationDbContext _context;

        public CiudadesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ciudades
        public async Task<IActionResult> Index()
        {
              return View(await _context.ciudades.Include(c => c.sedes).ToListAsync());
        }

        // GET: Ciudades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ciudades == null)
            {
                return NotFound();
            }

            var ciudades = await _context.ciudades
                .Include(c => c.sedes)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ciudades == null)
            {
                return NotFound();
            }

            return View(ciudades);
        }

        // GET: Ciudades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ciudades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(ciudades);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }

                catch (Exception exception) { ModelState.AddModelError(string.Empty, exception.Message); }
            }
            return View(ciudades);
        }

        // GET: Ciudades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ciudades == null)
            {
                return NotFound();
            }

            var ciudades = await _context.ciudades.FindAsync(id);
            if (ciudades == null)
            {
                return NotFound();
            }
            return View(ciudades);
        }

        // POST: Ciudades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Ciudades ciudades)
        {
            if (id != ciudades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudades);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);

                    }
                }
                catch (Exception exception) { ModelState.AddModelError(string.Empty, exception.Message); }
            }
            return View(ciudades);
        }

        // GET: Ciudades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ciudades == null)
            {
                return NotFound();
            }

            var ciudades = await _context.ciudades
                .Include(c => c.sedes)
                .ThenInclude(u => u.usuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ciudades == null)
            {
                return NotFound();
            }

            _context.ciudades.Remove(ciudades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadesExists(int id)
        {
          return _context.ciudades.Any(e => e.Id == id);
        }


        public async Task<IActionResult> AddSede(int? id)
        {
            if (id == null) { 
                return NotFound(); 
            }
            Ciudades ciudades = await _context.ciudades.FindAsync(id); 
            if (ciudades == null) { 
                return NotFound(); 
            }
            Sedes model = new Sedes { Id = ciudades.Id }; 
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSede(Sedes sede)
        {
            if (ModelState.IsValid)
            {
                Ciudades ciudades = await _context.ciudades
                                .Include(c => c.sedes)
                                .FirstOrDefaultAsync(c => c.Id == sede.Id);

                if (ciudades == null) { return NotFound(); }

                try
                {
                    sede.Id = 0;
                    ciudades.sedes.Add(sede);
                    _context.Update(ciudades);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = ciudades.Id });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else { ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message); }
                }
                catch (Exception exception) { ModelState.AddModelError(string.Empty, exception.Message); }
            }
            return View(sede);
        }

        public async Task<IActionResult> EditSede(int? id)
        {
            if (id == null) { return NotFound(); }
            Sedes sedes = await _context.sedes.FindAsync(id); 
            if (sedes == null) { return NotFound(); }
            Ciudades ciudades = await _context.ciudades
                                .FirstOrDefaultAsync(c => c.sedes.FirstOrDefault(d => d.Id == sedes.Id) != null);
            sedes.Id = ciudades.Id; 
            return View(sedes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSede(Sedes sedes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sedes);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details),
                        new { Id = sedes.Id });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else { ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message); }
                }
                catch (Exception exception)
                {

                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(sedes);
        }

        //metodo borrado
        public async Task<IActionResult> DeleteSede(int? id)
        {
            if (id == null) { return NotFound(); }
            Sedes sedes = await _context.sedes.Include(d => d.usuarios).FirstOrDefaultAsync(m => m.Id == id);
            if (sedes == null) { return NotFound(); }
            Ciudades ciudades = await _context.ciudades
                                .FirstOrDefaultAsync(c => c.sedes.FirstOrDefault(d => d.Id == sedes.Id) != null);
            _context.sedes.Remove(sedes); await _context.SaveChangesAsync(); 
            return RedirectToAction(nameof(Details), new { Id = ciudades.Id });
        }

        public async Task<IActionResult> DetailsSede(int? id)
        {
            if (id == null) { return NotFound(); }
            Sedes sedes = await _context.sedes.Include(c => c.usuarios).FirstOrDefaultAsync(m => m.Id == id);
            if (sedes == null)
            {
                return NotFound();
            }

            Ciudades ciudades = await _context.ciudades.FirstOrDefaultAsync(c => c.sedes.FirstOrDefault(d => d.Id == sedes.Id) != null);

            sedes.Id = ciudades.Id; 
            return View(sedes);
        }

        // USUARIO
        public async Task<IActionResult> AddUsuario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Sedes sedes = await _context.sedes.FindAsync(id);
            if (sedes == null)
            {
                return NotFound();
            }
            Usuarios model = new Usuarios { id = sedes.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUsuario(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                Sedes sedes = await _context.sedes
                                .Include(c => c.usuarios)
                                .FirstOrDefaultAsync(c => c.Id == usuarios.id);

                if (sedes == null) { return NotFound(); }

                try
                {
                    usuarios.id = 0;
                    sedes.usuarios.Add(usuarios);
                    _context.Update(sedes);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = sedes.Id });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else { ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message); }
                }
                catch (Exception exception) { ModelState.AddModelError(string.Empty, exception.Message); }
            }
            return View(usuarios);
        }

        public async Task<IActionResult> EditUsuario(int? id)
        {
            if (id == null) { return NotFound(); }
            Usuarios usuarios = await _context.usuarios.FindAsync(id);
            if (usuarios == null) { return NotFound(); }
            Sedes sedes = await _context.sedes
                                .FirstOrDefaultAsync(c => c.usuarios.FirstOrDefault(d => d.id == usuarios.id) != null);
            usuarios.id = sedes.Id;
            return View(usuarios);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUsuario(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details),
                        new { Id = usuarios.id });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else { ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message); }
                }
                catch (Exception exception)
                {

                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(usuarios);
        }

        //metodo borrado
        public async Task<IActionResult> DeleteUsuario(int? id)
        {
            if (id == null) { return NotFound(); }
            Usuarios usuario = await _context.usuarios.FirstOrDefaultAsync(m => m.id == id);
            if (usuario == null) { return NotFound(); }
            Sedes sedes = await _context.sedes
                                .FirstOrDefaultAsync(c => c.usuarios.FirstOrDefault(d => d.id == usuario.id) != null);
            // ERROR
            _context.usuarios.Remove(usuario); 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Id = sedes.Id });
        }

        public async Task<IActionResult> DetailsUsuario(int? id)
        {
            if (id == null) { return NotFound(); }
            Usuarios usuarios = await _context.usuarios.FirstOrDefaultAsync(m => m.id == id);
            if (usuarios == null)
            {
                return NotFound();
            }
            Sedes sedes = await _context.sedes
                                .FirstOrDefaultAsync(c => c.usuarios.FirstOrDefault(d => d.id == usuarios.id) != null);
            usuarios.id = sedes.Id;
            return View(usuarios);
        }
    }
}
