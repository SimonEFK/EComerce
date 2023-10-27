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

        public int PageSize { get; set; }
    }
}
