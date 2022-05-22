using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerVehiculos.Data;

namespace TallerVehiculos.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CiudadesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public CiudadesController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_context.ciudades
                .Include(c => c.sedes)
                .ThenInclude(d => d.usuarios));
        }

    }
}