using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class Sedes
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]
        public string nombre { get; set; }  
        public int idCiudad { get; set; }
        public string direccion { get; set; }


    }
}
