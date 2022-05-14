using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]

        public string placa { get; set; }
      

        public string tipo { get; set; }
        public string modelo { get; set; }

       



    }
}
