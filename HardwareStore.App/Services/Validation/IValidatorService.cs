namespace HardwareStore.App.Services.Validation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IValidatorService
    {
        Task<bool> IsCategoryValidAsync(int categoryId);
        Task<bool> IsManufacturerValidAsync(int manufacturerId);
        Task<bool> IsManufacturerValidAsync(HashSet<int> manufacturerIds);
        Task<bool> IsProductValidAsync(int productId);
        bool IsSortOrderValueValid(string sortOrder);
        Task<bool> IsSpecificationValidAsync(int specificationId);
        Task<bool> IsSpecificationValueValidAsync(int valueId);
        Task<bool> IsSpecificationValueValidAsync(HashSet<int> valueIds);
    }
}
