using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class ProductViewModel : Productos

    {
        [Display(Name = "Image")]

        public IFormFile ImageFile { get; set; }

        [Display(Name = "Category")]

        [Range(1, int.MaxValue, ErrorMessage = "You must select a category.")]

        [Required]

        public int CategoryId { get; set; }



        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}
