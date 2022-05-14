using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]
        public string Nombre { get; set; }      
        public int nit { get; set; }
        public string correo { get; set; }

        public ICollection<Productos> productos { get; set; }
    }
}
