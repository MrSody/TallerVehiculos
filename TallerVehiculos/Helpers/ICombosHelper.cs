

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

using TallerVehiculos.Data;
using System.Collections.Generic;
using TallerVehiculos.Data;

namespace TallerVehiculos.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCategories();
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

    }
}
