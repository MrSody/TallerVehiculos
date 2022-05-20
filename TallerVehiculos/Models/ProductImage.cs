using System;
using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Models
{
    public class ProductImage
    {

        public int Id { get; set; }
        [Display(Name = "Image")] public Guid ImageId { get; set; }
        //TODO: Pending to put the correct paths
        [Display(Name = "Image")] public string ImageFullPath => ImageId == Guid.Empty ? $"https://tallervehiculos20220520150509.azurewebsites.net/images/noimage.png" : $"https://tallervehiculosdemo.blob.core.windows.net/categories/{ImageId}";
    }
}
