using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class Clientes
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]
        public string Nombre { get; set; }    

        public int edad { get; set; }   
        public string correo { get; set; }
        public ICollection<Factura> facturas { get; set; }

        public ICollection<Vehiculo> vehiculos { get; set; }

        [DisplayName("Vehiculos Number")] public int VehiculosNumber => vehiculos == null ? 0 : vehiculos.Count;

    }
}
