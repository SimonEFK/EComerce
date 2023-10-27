namespace HardwareStore.App.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryDataService
    {
        Task<ICollection<TModel>> GetCategories<TModel>(bool isEmpty = false);
    }
}
