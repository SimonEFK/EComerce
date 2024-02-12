namespace HardwareStore.App.Services.Data.Products
{
    using HardwareStore.App.Areas.Administration.Models.ProductManagment;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductDataService
    {
        Task<ServiceResult> CreateProduct(CreateProductFormModel productFormModel);
        Task<TModel?> GetProductById<TModel>(int id);

    }
}
