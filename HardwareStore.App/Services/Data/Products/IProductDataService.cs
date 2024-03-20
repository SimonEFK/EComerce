namespace HardwareStore.App.Services.Data.Products
{
    using System.Threading.Tasks;
    using HardwareStore.App.Services.Data.Products.Create;
    using HardwareStore.App.Services.Data.Products.Edit;

    public interface IProductDataService
    {
        Task<ServiceResult> CreateProduct(CreateProductDTO createProductDTO);
        Task<ServiceResult> EditProduct(EditProductDTO editProductDto);
        Task<TModel?> GetProductById<TModel>(int id);

    }
}
