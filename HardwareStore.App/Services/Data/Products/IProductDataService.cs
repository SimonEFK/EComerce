namespace HardwareStore.App.Services.Data.Products
{
    using HardwareStore.App.Areas.Administration.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductDataService
    {
        Task<ProductCreationStatus> CreateProduct(CreateProductFormModel productFormModel);
        Task<TModel?> GetProductById<TModel>(int id);

    }
}
