namespace HardwareStore.App.Services.Validation
{
    using HardwareStore.App.Data;
    using Microsoft.EntityFrameworkCore;

    public class ValidatorService : IValidatorService
    {
        private readonly ApplicationDbContext data;

        public ValidatorService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<bool> IsProductValidAsync(int productId)
        {
            return await data.Products.AnyAsync(x => x.Id == productId);
        }
        public async Task<bool> IsCategoryValidAsync(int categoryId)
        {
            return await data.Categories.AnyAsync(x => x.Id == categoryId);

        }
        public async Task<bool> IsManufacturerValidAsync(int manufacturerId)
        {
            return await data.Manufacturers.AnyAsync(x => x.Id == manufacturerId);

        }
        public async Task<bool> IsSpecificationValidAsync(int specificationId)
        {
            return await data.SpecificationValues.AnyAsync(x => x.SpecificationId == specificationId);
        }
        public async Task<bool> IsSpecificationValueValidAsync(int valueId)
        {
            return await data.SpecificationValues.AnyAsync(x => x.Id == valueId);
        }
    }
}
