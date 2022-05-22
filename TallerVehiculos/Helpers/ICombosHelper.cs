

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

using TallerVehiculos.Data;
using System.Collections.Generic;
using TallerVehiculos.Data;
using TallerVehiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace TallerVehiculos.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCategories();

        IEnumerable<SelectListItem> GetComboClientes();

        IEnumerable<SelectListItem> GetComboUsuarios();

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

        //        public IEnumerable<SelectListItem> GetComboCities(int departmentId) 

        //{ 

        //    List<SelectListItem> list = new List<SelectListItem>(); 

        //    Ciudades department = _context.ciudades 

        //        .Include(d => d.sedes) 

        //        .FirstOrDefault(d => d.Id == departmentId); 

        //    if (department != null) 

        //    { 

        //        list = department.sedes.Select(t => new SelectListItem 

        //        { 

        //            Text = t.nombre, 

        //            Value = $"{t.Id}" 

        //        }) 

        //            .OrderBy(t => t.Text) 

        //            .ToList(); 

        //    } 



        //    list.Insert(0, new SelectListItem 

        //    { 

        //        Text = "[Select a city...]", 

        //        Value = "0" 

        //    }); 



        //    return list; 

        //} 



        //public IEnumerable<SelectListItem> GetComboCountries() 

        //{ 

        //    List<SelectListItem> list = _context.sedes.Select(t => new SelectListItem 

        //    { 

        //        Text = t.nombre, 

        //        Value = $"{t.Id}" 

        //    }) 

        //        .OrderBy(t => t.Text) 

        //        .ToList(); 



        //    list.Insert(0, new SelectListItem 

        //    { 

        //        Text = "[Select a sede...]", 

        //        Value = "0" 

        //    }); 



        //    return list; 

        //} 



        //public IEnumerable<SelectListItem> GetComboDepartments(int countryId) 

        //{ 

        //    List<SelectListItem> list = new List<SelectListItem>(); 

        //    Sedes country = _context.sedes 

        //        .Include(c => c.nombre) 

        //        .FirstOrDefault(c => c.IdCiudades == countryId); 

        //    if (country != null) 

        //    { 

        //        list = country.usuarios.Select(t => new SelectListItem 

        //        { 

        //            Text = t.nombre, 

        //            Value = $"{t.id}" 

        //        }) 

        //            .OrderBy(t => t.Text) 

        //            .ToList(); 

        //    } 



        //    list.Insert(0, new SelectListItem 

        //    { 

        //        Text = "[Select a usuarios...]", 

        //        Value = "0" 

        //    }); 



        //    return list; 

        //} 







    }
}
