using System;
using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50)][Required] public string Name { get; set; }
        [Display(Name = "Image")] public Guid ImageId { get; set; }
        //TODO: Pending to put the correct paths
        [Display(Name = "Image")] public string ImageFullPath => ImageId == Guid.Empty ? "$https://localhost:44388/images/noimage.png"// luego cambiamos esta url por la de 
            //Azure
            : $"https://tallervehiculosdemo.blob.core.windows.net/categories/{ImageId}"; // blob en Azure }
    }
}
