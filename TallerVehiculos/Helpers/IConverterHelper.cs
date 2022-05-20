using System;
using System.Threading.Tasks;
using TallerVehiculos.Models;
using System;

using System.Threading.Tasks;

using TallerVehiculos.Models;
using TallerVehiculos.Data;

namespace TallerVehiculos.Helpers
{

    

    public interface IConverterHelper
    {
        Category ToCategory(CategoryViewModel model, Guid imageId, bool isNew);
        CategoryViewModel ToCategoryViewModel(Category category);
        Task<Productos> ToProductAsync(ProductViewModel model, bool isNew);



        ProductViewModel ToProductViewModel(Productos product);


    }

 

    public class ConverterHelper : IConverterHelper

    {
      

        private readonly AplicationDbContext _context;

        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(AplicationDbContext context, ICombosHelper combosHelper)

        {

            _context = context;

            _combosHelper = combosHelper;

        }

        public async Task<Productos> ToProductAsync(ProductViewModel model, bool isNew)

        {

            return new Productos

            {

                Category = await _context.Categories.FindAsync(model.CategoryId),

                descripcion = model.descripcion,

                Id = isNew ? 0 : model.Id,

                IsActive = model.IsActive,

                IsStarred = model.IsStarred,

                Nombre = model.Nombre,

                precio = model.precio,

                ProductImages = model.ProductImages

            };

        }



        public ProductViewModel ToProductViewModel(Productos product)

        {

            return new ProductViewModel

            {

                Categories = _combosHelper.GetComboCategories(),

                Category = product.Category,

                CategoryId = product.Category.Id,

                descripcion = product.descripcion,

                Id = product.Id,

                IsActive = product.IsActive,

                IsStarred = product.IsStarred,

                Nombre = product.Nombre,

                precio = product.precio,

                ProductImages = product.ProductImages

            };

        }



        public Category ToCategory(CategoryViewModel model, Guid imageId, bool isNew)

        {

            return new Category

            {

                Id = isNew ? 0 : model.Id,

                ImageId = imageId,

                Name = model.Name

            };

        }



        public CategoryViewModel ToCategoryViewModel(Category category)

        {

            return new CategoryViewModel

            {

                Id = category.Id,

                ImageId = category.ImageId,

                Name = category.Name

            };

        }

        

    }
}
