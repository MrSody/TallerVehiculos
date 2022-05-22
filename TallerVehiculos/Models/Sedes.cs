using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TallerVehiculos.Models
{
    //[Authorize(Roles = "Admin")]

    public class Sedes
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "el campo {0} debe contener almenos un caracter")]
        public string nombre { get; set; }
        public string direccion { get; set; }

        public ICollection<Usuarios> usuarios { get; set; }
        [DisplayName("Usuarios Number")] public int UsuariosNumber => usuarios == null ? 0 : usuarios.Count;

        //[JsonIgnore]
        //[NotMapped]
        //public int CiudadesId { get; set; }

        [JsonIgnore]
        public Ciudades Ciudades { get; set; }

    }
}
