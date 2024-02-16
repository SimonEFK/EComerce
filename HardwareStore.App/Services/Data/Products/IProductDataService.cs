namespace HardwareStore.App.Services.Data.Products
{
    using HardwareStore.App.Services.Models;
    using System.Threading.Tasks;

    public interface IProductDataService
    {
        Task<ServiceResult> CreateProduct(CreateProductDTO createProductDTO);
        Task<TModel?> GetProductById<TModel>(int id);

    }
}
