using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class Ciudades
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]
        public string Nombre { get; set; }

        public ICollection<Sedes> sedes { get; set; }
        [DisplayName("sedes Number")] public int SedesNumber => sedes == null ? 0 : sedes.Count;
    }
}