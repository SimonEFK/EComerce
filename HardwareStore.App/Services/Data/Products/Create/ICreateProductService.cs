namespace HardwareStore.App.Services.Data.Products.Create
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICreateProductService
    {
        ICreateProductService AddImages(HashSet<string> images);
        ICreateProductService AddSpecifications(HashSet<int> specificationValueIds);
        ICreateProductService CreateProduct(string name, string? nameDetailed, int categoryId, int manufacturerId);
        Task SaveChangesAsync();
    }
}