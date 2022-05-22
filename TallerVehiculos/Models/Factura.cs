using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerVehiculos.Models
{
    [Authorize(Roles = "Admin")]
    public class Factura
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]
        public string fecha { get; set; }
        public double total { get; set; }
        public ICollection<DetalleFactura> detalleFacturas { get; set; }


        //new
        [Required]
        [Display(Name = "Cliente")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a cliente.")]

        public int ClientesId { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Clientes { get; set; }


        [Required]
        [Display(Name = "Usuario")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a usuario.")]

        public int Usuariosid { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Usuario { get; set; }

    }
}
