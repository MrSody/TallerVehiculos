using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TallerVehiculos.Data;
using TallerVehiculos.Data.Entities;
using TallerVehiculos.Enums;
using TallerVehiculos.Helpers;
using TallerVehiculos.Models;

namespace TallerVehiculos.Controllers
{
    public class AccountController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IBlobHelper _blobHelper;


        public AccountController(
            AplicationDbContext context,
            IUserHelper userHelper,
            ICombosHelper combosHelper,
            IBlobHelper blobHelper

        )
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _blobHelper = blobHelper;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email or password incorrect.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult NotAuthorized()
        {
            return View();
        }

        public IActionResult Register()
        {
            AddUserViewModel model = new AddUserViewModel
            {
                Ciudades = _combosHelper.GetComboCiudades(),
                Sedes = _combosHelper.GetComboSedes(0),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                }

                User user = await _userHelper.AddUserAsync(model, imageId, UserType.User);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "This email is already used.");
                    model.Ciudades = _combosHelper.GetComboCiudades();
                    model.Sedes = _combosHelper.GetComboSedes(model.CiudadId);
                    return View(model);
                }

                LoginViewModel loginViewModel = new LoginViewModel
                {
                    Password = model.Password,
                    RememberMe = false,
                    Username = model.Username
                };

                var result2 = await _userHelper.LoginAsync(loginViewModel);

                if (result2.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            model.Ciudades = _combosHelper.GetComboCiudades();
            model.Sedes = _combosHelper.GetComboSedes(model.CiudadId);
            return View(model);
        }


        public JsonResult GetSedes(int ciudadesId)
        {
            Ciudades listCiudades = _context.ciudades.Include(c => c.sedes).FirstOrDefault(c => c.Id == ciudadesId);
            if (listCiudades == null)
            {
                return null;
            }

            return Json(listCiudades.sedes.OrderBy(d => d.nombre));
        }






    }

}
