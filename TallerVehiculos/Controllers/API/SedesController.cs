using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TallerVehiculos.Data;


namespace TallerVehiculos.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class SedesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public SedesController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.sedes);
                //.Where(p => p.IsActive));
        }

    }
}
