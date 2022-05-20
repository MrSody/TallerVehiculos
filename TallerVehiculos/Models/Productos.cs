using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TallerVehiculos.Models
{
    public class Productos
    {



        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        
        public string Nombre { get; set; }
        [DataType(DataType.MultilineText)] 
        
        public string descripcion { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")] 
        
        public double precio { get; set; }
        [DisplayName("Is Active")]
        
        public bool IsActive { get; set; }
        [DisplayName("Is Starred")] 
        
        public bool IsStarred { get; set; }

        public Category Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
        [DisplayName("Product Images Number")] public int ProductImagesNumber => ProductImages == null ? 0 : ProductImages.Count;
        //TO DO: Pendiente cambiar los paths por los de Azure
        [Display(Name = "Image")] public string ImageFullPath => ProductImages == null || ProductImages.Count == 0 ? $"https://tallervehiculos20220520150509.azurewebsites.net/Images/noimage.png" : $"https://tallervehiculosdemo.blob.core.windows.net/productos/{ProductImages}";


        public ICollection<DetalleFactura> detalleFacturas { get; set; }


    }
}
