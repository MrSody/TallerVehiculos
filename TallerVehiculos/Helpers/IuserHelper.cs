using Microsoft.AspNetCore.Identity;

using System.Threading.Tasks;

using TallerVehiculos.Data.Entities;

using System.Threading.Tasks;

using TallerVehiculos.Data;
using Microsoft.EntityFrameworkCore;

namespace TallerVehiculos.Helpers
{
    public interface IuserHelper
    {
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



        public UserHelper(AplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)

        {

            _context = context;

            _userManager = userManager;

            _roleManager = roleManager;

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

    }
}
