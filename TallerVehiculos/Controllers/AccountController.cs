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

        private readonly IuserHelper _userHelper;

        private readonly ICombosHelper _combosHelper;

        private readonly IBlobHelper _blobHelper;



        public AccountController(AplicationDbContext context,

        IuserHelper userHelper,

        ICombosHelper combosHelper,

        IBlobHelper blobHelper) 

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


        public IActionResult Register()

        {

            AddUserViewModel model = new AddUserViewModel

            {

                //Countries = _combosHelper.GetComboCountries(),

                //Departments = _combosHelper.GetComboDepartments(0),

                //Cities = _combosHelper.GetComboCities(0),

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

                    //model.Countries = _combosHelper.GetComboCountries();

                    //model.Departments = _combosHelper.GetComboDepartments(model.CountryId);

                    //model.Cities = _combosHelper.GetComboCities(model.DepartmentId);

                    return View(model);

                }



                LoginViewModel loginViewModel = new LoginViewModel
                {

                    //Password = model.Password,

                    //RememberMe = false,

                    //Username = model.Username

                };



                var result2 = await _userHelper.LoginAsync(loginViewModel);



                if (result2.Succeeded)

                {

                    return RedirectToAction("Index", "Home");

                }

            }



            //model.Countries = _combosHelper.GetComboCountries();

            //model.Departments = _combosHelper.GetComboDepartments(model.CountryId);

            //model.Cities = _combosHelper.GetComboCities(model.DepartmentId);

            return View(model);

        }





        public JsonResult GetDepartments(int countryId)

        {

            Clientes country = _context.clientes

                .Include(c => c.vehiculos)

                .FirstOrDefault(c => c.Id == countryId);

            if (country == null)

            {

                return null;

            }



            return Json(country.vehiculos.OrderBy(d => d.placa));

        }



        public JsonResult GetCities(int departmentId)

        {

            Vehiculo department = _context.vehiculo

                .Include(d => d.servicios)

                .FirstOrDefault(d => d.Id == departmentId);

            if (department == null)

            {

                return null;

            }



            return Json(department.servicios.OrderBy(c => c.Nombre));

        }

    }
}
