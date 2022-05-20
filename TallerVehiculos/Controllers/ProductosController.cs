using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

using TallerVehiculos.Data;

using TallerVehiculos.Helpers;
namespace TallerVehiculos.Controllers
{
    public class ProductosController : Controller

    {

        private readonly AplicationDbContext _context;

        private readonly IBlobHelper _blobHelper;

        private readonly ICombosHelper _combosHelper;

        private readonly IConverterHelper _converterHelper;



        public ProductosController(AplicationDbContext context, IBlobHelper blobHelper, ICombosHelper combosHelper, IConverterHelper converterHelper)

        {

            _context = context;

            _blobHelper = blobHelper;

            _combosHelper = combosHelper;

            _converterHelper = converterHelper;

        }



        public async Task<IActionResult> Index()

        {

            return View(await _context.productos

                .Include(p => p.Category)

                .Include(p => p.ProductImages)

                .ToListAsync());

        }

    }
}
