using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerVehiculos.Data;
using TallerVehiculos.Helpers;
using TallerVehiculos.Models;

namespace TallerVehiculos.Controllers
{
    public class FacturasController : Controller
    {
        private readonly AplicationDbContext _context;
        //new
        private readonly ICombosHelper _combosHelper;


        public FacturasController(AplicationDbContext context, ICombosHelper combosHelper)
        {
            _context = context;
            //new
            _combosHelper = combosHelper;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
              return View(await _context.facturas
                  .Include(c => c.detalleFacturas)
                  .ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.facturas
                .Include(f => f.detalleFacturas)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            Factura model = new Factura
            {
                Clientes = _combosHelper.GetComboClientes(),
                Usuario = _combosHelper.GetComboUsuarios(),
            };

            return View(model);
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,fecha,total,ClientesId,Usuariosid")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(factura);
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
                        //factura.Clientes = _combosHelper.GetComboClientes(factura.ClientesId);
                        //factura.Usuario = _combosHelper.GetComboUsuarios(factura.Usuariosid);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fecha,total")] Factura factura)
        {
            if (id != factura.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
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
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        
            {
                if (id == null) { return NotFound(); }
                Factura factura = await _context.facturas.FirstOrDefaultAsync(m => m.Id == id); 
                if (factura == null) { return NotFound(); }
                _context.facturas.Remove(factura); 
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index));
            }
        

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.facturas == null)
            {
                return Problem("Entity set 'AplicationDbContext.facturas'  is null.");
            }
            var factura = await _context.facturas.FindAsync(id);
            if (factura != null)
            {
                _context.facturas.Remove(factura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> AddDetalleFactura(int? id)
        {
            if (id == null) { return NotFound(); }
            Factura factura = await _context.facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            DetalleFactura model = new DetalleFactura { Id = factura.Id };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDetalleFactura(DetalleFactura detalleFactura)
        {

            if (ModelState.IsValid)
            {
                Factura factura = await _context.facturas.Include(c => c.detalleFacturas).FirstOrDefaultAsync(c => c.Id == detalleFactura.Id); if (factura == null) { return NotFound(); }
                try
                {
                    detalleFactura.Id = 0;
                    factura.detalleFacturas.Add(detalleFactura);
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = factura.Id });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception) { ModelState.AddModelError(string.Empty, exception.Message); }
            }
            return View(detalleFactura);
        }



    }
}
