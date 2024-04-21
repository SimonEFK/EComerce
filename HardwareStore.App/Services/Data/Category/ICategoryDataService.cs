namespace HardwareStore.App.Services.Data.Category
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryDataService
    {
        Task<CategoryInfoDTO> CategoryInfoAsync(int categoryId);

        Task<ServiceResult> CreateCategoryAsync(string? name = null, string? ImageUrl = null);

        Task<ServiceResult> CreateSpecificationAsync(int categoryId, string? name = null, bool isFilter = false, bool isEssential = false);

        Task<ServiceResult> CreateSpecificationValueAsync(int categoryId, int specificationId, string? value = null, string? metric = null);

        Task<ServiceResult> EditCategoryAsync(int id, string? name = null, string? imageUrl = null, string? imageFilePath = null);

        Task<ServiceResult> EditSpecificationAsync(int categoryId, int id, string? name = null, bool isFilter = false, bool isEssential = false);

        Task<ServiceResult> EditSpecificationValueAsync(int categoryId, int specificationId, int valueId, string? value = null, string? metric = null);

        Task<ICollection<TModel>> GetCategoriesAsync<TModel>();

        Task<ICollection<(string Name, int Id)>> GetCategoriesAsTupleCollectionAsync();

        Task<SpecificationInfoDTO> SpecificationInfoAsync(int specificationId);
        
    }
}
