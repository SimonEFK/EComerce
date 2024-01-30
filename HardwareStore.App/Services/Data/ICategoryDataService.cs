namespace HardwareStore.App.Services.Data
{
    using HardwareStore.App.Areas.Administration.Models;
    using HardwareStore.App.Services.Data.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryDataService
    {
        Task<CategoryInfoModel> CategoryInfo(int categoryId);
        Task<CreationStatus> CreateCategory(CategoryFormModel model);
        Task EditCategory(int id, string name, string url, bool downloadImage = false);
        Task<ICollection<TModel>> GetCategories<TModel>(bool isEmpty = false);

        ICollection<(string Name, int Id)> GetCategoriesAsTupleCollection();

        ICollection<KeyValuePair<string, int>> GetCategorySpecifications(int categoryId);
        ICollection<KeyValuePair<string, int>> GetSpecificationValues(int specificationId);
    }
}
