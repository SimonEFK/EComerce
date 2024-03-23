namespace HardwareStore.App.Services.Data.Products.ProductSpecifications
{
    using System.Threading.Tasks;

    public interface IProductSpecificationService
    {
        Task<ServiceResult> AddSpecificationAsync(int productId, int valueId);
        Task<ServiceResult> RemoveSpecificationAsync(int productId, int valueId);
    }
}