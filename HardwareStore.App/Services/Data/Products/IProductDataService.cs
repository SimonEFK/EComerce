namespace HardwareStore.App.Services.Data.Products
{
    using HardwareStore.App.Models.Product;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductDataService
    {
        void CreateProduct(CreateProductFormModel productFormModel);
        Task<TModel?> GetProductById<TModel>(int id);
       
    }
}
