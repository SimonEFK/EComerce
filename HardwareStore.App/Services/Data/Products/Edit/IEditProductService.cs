namespace HardwareStore.App.Services.Data.Products.Edit
{
    using System.Threading.Tasks;

    public interface IEditProductService
    {
        Task EditProduct(int id, string name, string? nameDetailed, int categoryId, int manufacturerId);
    }
}