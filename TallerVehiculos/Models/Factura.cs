using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class Factura
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]
        public string fecha { get; set; }
        public double total { get; set; }
        public ICollection<DetalleFactura> detalleFacturas { get; set; }

    }
}
