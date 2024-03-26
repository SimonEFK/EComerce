namespace HardwareStore.App.Services.ProductFiltering
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.ProductFilter;
    using System;

    public interface IGenerateProductFilterOptionService
    {
        Task<ICollection<Tuple<string, int, int>>> GenerateManufacturerOptions(int? categoryId, string? searchString = null);
        ICollection<string> GenerateSortOrderOptions();
        Task<Dictionary<string, List<SpecificationFilterOption>>> GenerateSpecificationOptions(int? categoryId, string? searchString = null);
    }
}
