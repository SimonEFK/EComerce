namespace HardwareStore.App.Services.Data
{
    using HardwareStore.App.Services.Data.Products;
    using HardwareStore.App.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryDataService
    {
        Task<CategoryOutputModel> CategoryInfo(int categoryId);

        Task<ServiceResult> CreateCategory(string name, string ImageUrl);

        Task<ServiceResult> CreateSpecification(int categoryId, string name, bool isFilter = false, bool isEssential = false);
        Task<ServiceResult> CreateSpecificationValue(int categoryId, int specificationId, string value, string? metric);

        Task<ServiceResult> EditCategory(int id, string name, string imageUrl, string imageFilePath);

        Task<ServiceResult> EditSpecification(int categoryId, int id, string name, bool isFilter = false, bool isEssential = false);
        Task<ServiceResult> EditSpecificationValue(int categoryId, int specificationId, int valueId, string value, string? metric);

        Task<ICollection<TModel>> GetCategories<TModel>();

        Task<ICollection<(string Name, int Id)>> GetCategoriesAsTupleCollectionAsync();

        Task<SpecificationOutputModel> SpecificationInfo(int specificationId);
    }
}
