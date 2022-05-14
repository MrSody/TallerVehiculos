using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]
        public int cantidad { get; set; }
        public double total { get; set; }
      

    }
}
