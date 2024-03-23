namespace HardwareStore.App.Services.Data.Products
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HardwareStore.App.Services.Data.Products.Create;
    using HardwareStore.App.Services.Data.Products.Edit;

    public interface IProductDataService
    {
        Task<TModel?> GetProductById<TModel>(int id);

        Task<ServiceResult> AddImageAsync(int productId, string imageUrl);

        Task<ServiceResult> AddSpecificationAsync(int productId, int valueId);
        
        Task<ServiceResultGeneric<T>> CreateProductAsync<T>(CreateProductDTO createProductDTO);
        
        Task<ServiceResultGeneric<T>> EditProductAsync<T>(EditProductDTO editProductDto);

        Task<ServiceResult> RemoveImageAsync(int productId, string imageId);

        Task<ServiceResult> RemoveSpecificationAsync(int productId, int valueId);

        Task<IEnumerable<TModel>> GetAll<TModel>();
    }
}
