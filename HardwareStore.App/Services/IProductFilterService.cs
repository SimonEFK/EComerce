namespace HardwareStore.App.Services
{
    using HardwareStore.App.Models.ProductFilter;

    public interface IProductFilterService
    {
        Task<ICollection<SpecificationFilterOption>> GenerateSpecificationOptions(string category);
    }
}
