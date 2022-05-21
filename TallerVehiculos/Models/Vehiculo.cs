using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    [Authorize(Roles = "Admin")]

    public class Vehiculo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]

        public string placa { get; set; }


        public string tipo { get; set; }
        public string modelo { get; set; }


        public ICollection<Servicio> servicios { get; set; }
        [DisplayName("Servicios Number")] public int ServiciosNumber => servicios == null ? 0 : servicios.Count;

        
    }
}
