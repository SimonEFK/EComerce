namespace HardwareStore.App.Services
{
    using HardwareStore.App.Models.ProductFilter;

    public interface IProductFilterService
    {
        ICollection<string> GenerateSortOrderOptions();
        Task<ICollection<SpecificationFilterOption>> GenerateSpecificationOptions(string category);
    }
}
