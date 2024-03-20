namespace HardwareStore.App.Services.Data.Products.ProductSpecifications
{
    using System.Threading.Tasks;

    public interface IProductSpecificationService
    {
        Task AddSpecification(int productId, int valueId);
        Task RemoveSpecification(int productId, int valueId);
    }
}