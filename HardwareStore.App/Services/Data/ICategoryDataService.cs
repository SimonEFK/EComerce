namespace HardwareStore.App.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryDataService
    {
        Task<ICollection<TModel>> GetCategories<TModel>(bool isEmpty = false);

        ICollection<(string Name, int Id)> GetCategoriesAsTupleCollection();

        ICollection<KeyValuePair<string, int>> GetCategorySpecifications(int categoryId);
        ICollection<KeyValuePair<string, int>> GetSpecificationValues(int specificationId);
    }
}
