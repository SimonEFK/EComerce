namespace HardwareStore.App.Services.Data
{
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;
    using HardwareStore.App.Services.Data.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryDataService
    {
        Task<CategoryInfoModel> CategoryInfo(int categoryId);
        Task<ServiceResult> CreateCategory(string name, string ImageUrl);
        Task<ServiceResult> CreateSpecification(SpecificationCreateModel model);
        Task<ServiceResult> CreateSpecificationValue(SpecificationValueCreateModel model);
        Task<ServiceResult> EditCategory(int id, string name, string imageUrl, string imageFilePath);
        Task<ServiceResult> EditSpecification(SpecificationEditModel model);
        Task<ServiceResult> EditSpecificationValue(SpecificationValueEditModel model);
        Task<ICollection<TModel>> GetCategories<TModel>();

        Task<ICollection<(string Name, int Id)>> GetCategoriesAsTupleCollectionAsync();
        Task<SpecificationInfoModel> SpecificationInfo(int specificationId);
    }
}
