using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerVehiculos.Data;
using TallerVehiculos.Models;
public class SeedDb
{
    private readonly AplicationDbContext _context;
    public SeedDb(AplicationDbContext context)
    {
        _context = context;
    }
    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
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
                        usuarios = new List<Usuarios>
                        {
                            new Usuarios
                            {
                                nombre = "cristian",
                                edad = 27,
                                correo = "cristian@prueba.com",
                            },
                            new Usuarios
                            {
                                nombre = "brandon",
                                edad = 22,
                                correo = "brandon@prueba.com",
                            },
                        }
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
}