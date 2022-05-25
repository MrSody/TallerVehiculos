using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerVehiculos.Data;
using TallerVehiculos.Data.Entities;
using TallerVehiculos.Enums;
using TallerVehiculos.Helpers;
using TallerVehiculos.Models;

public class SeedDb
{
    private readonly AplicationDbContext _context;
    private readonly IUserHelper _userHelper;

    public SeedDb(AplicationDbContext context, IUserHelper userHelper)
    {
        _context = context;
        _userHelper = userHelper;
    }
    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
        await CheckRolesAsync();
        await CheckUserAsync("1010", "Brandon", "A", "brandon@gmail.com", "3000000000", "1", UserType.Admin);
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.ciudades.Any())
        {
            _context.ciudades.Add(new Ciudades
            {
                Nombre = "Medellin",
                sedes = new List<Sedes>
                {
                    new Sedes
                    {
                        nombre = "Reparacion autos",
                        direccion = "calle 49",
                    },
                     new Sedes
                     {
                        nombre = "Autos reparing",
                        direccion = "calle 4",
                    }
                }
            });
            _context.ciudades.Add(new Ciudades
            {
                Nombre = "Bogota",
                sedes = new List<Sedes>
                {
                    new Sedes
                    {
                        nombre = "Reparaciones y arreglos",
                        direccion = "calle 20",
                    },
                    new Sedes
                    {
                        nombre = "Reparacion y lujos",
                        direccion = "calle 150b",
                    }
                }
            });
            await _context.SaveChangesAsync();
        }

    }

    private async Task CheckRolesAsync()
    {
        await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
        await _userHelper.CheckRoleAsync(UserType.User.ToString());
    }

    private async Task<User> CheckUserAsync(
        string document,
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
        UserType userType)
    {
        User user = await _userHelper.GetUserAsync(email);
        if (user == null)
        {
            user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                PhoneNumber = phone,
                Address = address,
                Document = document,
                Sedes = _context.sedes.FirstOrDefault(),
                UserType = userType
            };

            await _userHelper.AddUserAsync(user, "123456");
            await _userHelper.AddUserToRoleAsync(user, userType.ToString());
        }

        return user;
    }
}