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
    public class ClientesController : Controller
    {
        private readonly AplicationDbContext _context;

        public ClientesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.clientes
                .Include(c => c.vehiculos)
                .ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.clientes
                .Include(c => c.vehiculos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,edad,correo")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(clientes);
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
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,edad,correo")] Clientes clientes)
        {
            if (id != clientes.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
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
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) {
                return NotFound(); 
            }
            Clientes clientes = await _context.clientes.Include(c => c.vehiculos).ThenInclude(d => d.servicios).FirstOrDefaultAsync(m => m.Id == id);
            if (clientes == null)
            {
                return NotFound();
            }
            _context.clientes.Remove(clientes); await _context.SaveChangesAsync(); 
            return RedirectToAction(nameof(Index));
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _context.clientes.FindAsync(id);
            _context.clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> AddVehiculo(int? id)
        {
            if (id == null) { return NotFound(); }
            Clientes country = await _context.clientes.FindAsync(id);
            if (country == null) { return NotFound();
            }
            Vehiculo model = new Vehiculo { Id = country.Id };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehiculo(Vehiculo vehiculo)
        {
            
        if (ModelState.IsValid)
            {
                Clientes clientes = await _context.clientes.Include(c => c.vehiculos).FirstOrDefaultAsync(c => c.Id == vehiculo.Id); if (clientes == null) { return NotFound(); }
                try
                {
                    vehiculo.Id = 0; 
                    clientes.vehiculos.Add(vehiculo);
                    _context.Update(clientes); 
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = clientes.Id });
                }
                catch (DbUpdateException dbUpdateException) { 
                    if (dbUpdateException.InnerException.Message.Contains("duplicate")) {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name."); 
                    } else {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message); } }
                catch (Exception exception) { ModelState.AddModelError(string.Empty, exception.Message); }
            }
            return View(vehiculo);
        }




        public async Task<IActionResult> EditVehiculo(int? id)
        {
            if (id == null) 
            { 
                return NotFound(); 
            }
            Vehiculo vehiculo = await _context.vehiculo.FindAsync(id); 
            if (vehiculo == null) 
            { 
                return NotFound(); 
            }
            Clientes cliente = await _context.clientes.FirstOrDefaultAsync(c => c.vehiculos.FirstOrDefault(d => d.Id == vehiculo.Id) != null);
            vehiculo.Id = cliente.Id; return View(vehiculo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVehiculo(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo); await _context.SaveChangesAsync(); 
                    return RedirectToAction(nameof(Details), new { Id = vehiculo.Id });
                }
                catch (DbUpdateException dbUpdateException) {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    { ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    } else { ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message); } }
                catch (Exception exception)
                {
                    
                 ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(vehiculo);
        }



        public async Task<IActionResult> DeleteVehiculo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Vehiculo vehiculo = await _context.vehiculo.Include(d => d.servicios).FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            Clientes clientes = await _context.clientes.FirstOrDefaultAsync(c => c.vehiculos.FirstOrDefault(d => d.Id == vehiculo.Id) != null);
            _context.vehiculo.Remove(vehiculo); await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Id = clientes.Id });
        }



        public async Task<IActionResult> DetailsVehiculo(int? id)
        {
            if (id == null) { 
                return NotFound(); 
            }
            Vehiculo vehiculo = await _context.vehiculo.Include(d => d.servicios).FirstOrDefaultAsync(m => m.Id == id); 
            if (vehiculo == null) { return NotFound(); 
            }
            Clientes clientes = await _context.clientes.FirstOrDefaultAsync(c => c.vehiculos.FirstOrDefault(d => d.Id == vehiculo.Id) != null);
            vehiculo.Id = clientes.Id; 
            return View(clientes);
        }




        public async Task<IActionResult> AddServicio(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            Vehiculo vehiculo = await _context.vehiculo.FindAsync(id); if (vehiculo == null) { return NotFound(); }
            Servicio model = new Servicio { Id = vehiculo.Id }; 
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddServicio(Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                Vehiculo vehiculo = await _context.vehiculo.Include(d => d.servicios).FirstOrDefaultAsync(c => c.Id == servicio.Id);
                if (vehiculo == null) {
                    return NotFound();
                }
                try

                { servicio.Id = 0;
                    vehiculo.servicios.Add(servicio); 
                    _context.Update(vehiculo); 
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(DetailsVehiculo), new { Id = vehiculo.Id }); 
                } catch (DbUpdateException dbUpdateException) 
                { if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    { ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    } else { ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception) { ModelState.AddModelError(string.Empty, exception.Message); }
            }
            return View(servicio);
        }




    }
}
