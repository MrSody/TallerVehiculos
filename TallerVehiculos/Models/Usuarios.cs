using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class Usuarios
    {
        public int id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]
        public string nombre { get; set; }
        public int edad { get; set; }
        public string correo { get; set; }

        public int IdSedes { get; set; }

        public ICollection<Factura> facturas { get; set; }

    }
}


