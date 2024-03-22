namespace HardwareStore.App.Services.Data.Products.Edit
{
    using System.Threading.Tasks;

    public interface IEditProductService
    {
        Task AddImage(int id, string url);
        Task EditProduct(int id, string name, string? nameDetailed, int categoryId, int manufacturerId);
        Task RemoveImage(int id, string imageId);
    }
}