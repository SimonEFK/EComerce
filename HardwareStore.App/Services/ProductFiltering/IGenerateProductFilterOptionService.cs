namespace HardwareStore.App.Services.ProductFiltering
{
    using HardwareStore.App.Models.ProductFilter;
    using System;

    public interface IGenerateProductFilterOptionService
    {
        ICollection<Tuple<string, int>> GenerateManufacturerOptions(string manufacturer);
        ICollection<string> GenerateSortOrderOptions();
        Task<ICollection<SpecificationFilterOption>> GenerateSpecificationOptions(string category);
    }
}
