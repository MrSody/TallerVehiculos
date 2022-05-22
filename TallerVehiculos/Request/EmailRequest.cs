using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Request
{
    public class EmailRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

    }
}
