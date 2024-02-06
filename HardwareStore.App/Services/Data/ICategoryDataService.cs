﻿namespace HardwareStore.App.Services.Data
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
        Task<CreationStatus> CreateCategory(CategoryCreateModel model);
        Task<CreationStatus> CreateSpecification(SpecificationCreateModel model);
        Task EditCategory(int id, string name, string url, bool downloadImage = false);
        Task<CreationStatus> EditSpecification(SpecificationEditModel model);
        Task<ICollection<TModel>> GetCategories<TModel>();

        ICollection<(string Name, int Id)> GetCategoriesAsTupleCollection();
        Task<SpecificationInfoModel> SpecificationInfo(int specificationId);
    }
}
