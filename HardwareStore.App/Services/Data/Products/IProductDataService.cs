namespace HardwareStore.App.Services.Data.Products
{
    using System.Threading.Tasks;

    public interface IProductDataService
    {
        Task<ServiceResult> CreateProduct(CreateProductDTO createProductDTO);
        Task<TModel?> GetProductById<TModel>(int id);

    }
}
