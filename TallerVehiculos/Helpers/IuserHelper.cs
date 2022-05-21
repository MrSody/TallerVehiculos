using Microsoft.AspNetCore.Identity;

using System.Threading.Tasks;

using TallerVehiculos.Data.Entities;

using System.Threading.Tasks;

using TallerVehiculos.Data;
using Microsoft.EntityFrameworkCore;
using TallerVehiculos.Models;
using System;
using TallerVehiculos.Enums;
using System.Linq;

namespace TallerVehiculos.Helpers
{
    public interface IuserHelper
    {

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task<User> AddUserAsync(AddUserViewModel model, Guid imageId, UserType userType);

        Task LogoutAsync();

        Task<User> GetUserAsync(string email);



        Task<IdentityResult> AddUserAsync(User user, string password);



        Task CheckRoleAsync(string roleName);



        Task AddUserToRoleAsync(User user, string roleName);



        Task<bool> IsUserInRoleAsync(User user, string roleName);
    }


    public class UserHelper : IuserHelper

    {

        private readonly AplicationDbContext _context;

        private readonly UserManager<User> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly SignInManager<User> _signInManager;


        public UserHelper(AplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager) 

        {

            _context = context;

            _userManager = userManager;

            _roleManager = roleManager;

                _signInManager = signInManager; 
        }



        public async Task<IdentityResult> AddUserAsync(User user, string password)

        {
            
            return await _userManager.CreateAsync(user, password);

        }



        public async Task AddUserToRoleAsync(User user, string roleName)

        {

            await _userManager.AddToRoleAsync(user, roleName);

        }



        public async Task CheckRoleAsync(string roleName)

        {

            bool roleExists = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExists)

            {

                await _roleManager.CreateAsync(new IdentityRole

                {

                    Name = roleName

                });

            }

        }



        public async Task<User> GetUserAsync(string email)

        {

            return await _context.Users

                .Include(u => u.City)

                .FirstOrDefaultAsync(u => u.Email == email);

        }



        public async Task<bool> IsUserInRoleAsync(User user, string roleName)

        {

            return await _userManager.IsInRoleAsync(user, roleName);

        }


        public async Task<SignInResult> LoginAsync(LoginViewModel model)

        {

            return await _signInManager.PasswordSignInAsync(

                model.Username,

                model.Password,

                model.RememberMe,

                false);

        }



        public async Task LogoutAsync()

        {

            await _signInManager.SignOutAsync();

        }

        public async Task<User> AddUserAsync(AddUserViewModel model, Guid imageId, UserType userType)

        {

            User user = new User

            {

                Address = model.Address,

                Document = model.Document,

                Email = model.Username,

                FirstName = model.FirstName,

                LastName = model.LastName,

                ImageId = imageId,

                PhoneNumber = model.PhoneNumber,

                City = await _context.ciudades.FindAsync(model.CityId),

                UserName = model.Username,

                UserType = userType

            };



            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (result != IdentityResult.Success)

            {

                return null;

            }



            User newUser = await GetUserAsync(model.Username);

            await AddUserToRoleAsync(newUser, user.UserType.ToString());

            return newUser;

        }

    }
}
