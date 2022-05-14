using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class Sedes
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]
        public string nombre { get; set; }
        public string direccion { get; set; }
        public ICollection<Usuarios> usuario { get; set; }
        [DisplayName("Usuarios Number")] public int UsuariosNumber => usuario == null ? 0 : usuario.Count;
    }
}
