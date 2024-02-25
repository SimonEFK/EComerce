namespace HardwareStore.App.Services.ProductFiltering
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.ProductFilter;
    using System;

    public interface IGenerateProductFilterOptionService
    {
        ICollection<Tuple<string, int,int>> GenerateManufacturerOptions(IQueryable<Product> productQuery);
        ICollection<string> GenerateSortOrderOptions();
        Task<Dictionary<string, List<SpecificationFilterOption>>> GenerateSpecificationOptions(IQueryable<Product> productQuery);
    }
}
