namespace HardwareStore.App.Services.Data.Products
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductDataService
    {
        
        Task<TModel?> GetProductById<TModel>(int id);
       
    }
}
