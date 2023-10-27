namespace HardwareStore.App.Services.Data.Products
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductDataService
    {
        Task<ICollection<TModel>> GetProducts<TModel>(ICollection<int> selectedSpecificationsIds,
            string? category,
            string? searchString,
            string sortOrder = "newest",
            int pageNumber = 1);
        Task<TModel?> GetProductById<TModel>(int id);

        public int PageSize { get; set; }
    }
}
