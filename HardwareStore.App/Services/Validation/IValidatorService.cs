namespace HardwareStore.App.Services.Validation
{
    using System.Threading.Tasks;

    public interface IValidatorService
    {
        Task<bool> IsCategoryValidAsync(int categoryId);
        Task<bool> IsManufacturerValidAsync(int manufacturerId);
        Task<bool> IsProductValidAsync(int productId);
        Task<bool> IsSpecificationValidAsync(int specificationId);
        Task<bool> IsSpecificationValueValidAsync(int valueId);
    }
}
