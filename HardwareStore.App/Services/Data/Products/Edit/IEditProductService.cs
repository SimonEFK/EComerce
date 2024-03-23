namespace HardwareStore.App.Services.Data.Products.Edit
{
    using System.Threading.Tasks;

    public interface IEditProductService
    {
        Task<ServiceResult> AddImageAsync(int id, string url);
        Task<ServiceResult> AddSpecificationAsync(int productId, int valueId);
        Task<ServiceResultGeneric<T>> EditProductAsync<T>(int id, string name, string? nameDetailed, int categoryId, int manufacturerId);
        Task<ServiceResult> RemoveImageAsync(int id, string imageId);
        Task<ServiceResult> RemoveSpecificationAsync(int productId, int valueId);
    }
}