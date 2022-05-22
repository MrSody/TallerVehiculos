
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using TallerVehiculos.Data;
using System.Collections.Generic;
using TallerVehiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace TallerVehiculos.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCategories();
        IEnumerable<SelectListItem> GetComboClientes();
        IEnumerable<SelectListItem> GetComboUsuarios();

        IEnumerable<SelectListItem> GetComboCiudades();
        IEnumerable<SelectListItem> GetComboSedes(int ciudadId);

    }

    public class CombosHelper : ICombosHelper
    {
        private readonly AplicationDbContext _context;

        public CombosHelper(AplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboCategories()
        {
            List<SelectListItem> list = _context.Categories.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = $"{t.Id}"
            })
            .OrderBy(t => t.Text)
            .ToList();


            list.Insert(0, new SelectListItem
            {
                Text = "[Select a category...]",
                Value = "0"
            });


            return list;
        }

        public IEnumerable<SelectListItem> GetComboClientes()
        {

            List<SelectListItem> list = _context.clientes.Select(t => new SelectListItem
            {
                Text = t.Nombre,
                Value = $"{t.Id}"
            })
            .OrderBy(t => t.Text)
            .ToList();


            list.Insert(0, new SelectListItem
            {
                Text = "[Selecciona un cliente...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboUsuarios()
        {

            List<SelectListItem> list = _context.usuarios.Select(t => new SelectListItem
            {
                Text = t.nombre,
                Value = $"{t.id}"
            })
            .OrderBy(t => t.Text)
            .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Selecciona un usuario...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboCiudades()
        {
            List<SelectListItem> list = _context.ciudades.Select(t => new SelectListItem
            {
                Text = t.Nombre,
                Value = $"{t.Id}"
            })
            .OrderBy(t => t.Text)
            .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a ciudad...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboSedes(int ciudadId)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            Ciudades ciudades = _context.ciudades
                .Include(c => c.sedes)
                .FirstOrDefault(c => c.Id == ciudadId);
            if (ciudades != null)
            {
                list = ciudades.sedes.Select(t => new SelectListItem
                {
                    Text = t.nombre,
                    Value = $"{t.Id}"
                })
                .OrderBy(t => t.Text)
                .ToList();
            }

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a sedes...]",
                Value = "0"
            });

            return list;
        }


    }
}
