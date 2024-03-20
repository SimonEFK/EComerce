namespace HardwareStore.App.Services.Data.Products
{
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Services.Validation;
    using Microsoft.EntityFrameworkCore;

    public class ProductSpecificationService : IProductSpecificationService
    {
        private IValidatorService validatorService;
        private ApplicationDbContext dbContext;

        public ProductSpecificationService(IValidatorService validatorService, ApplicationDbContext dbContext)
        {
            this.validatorService = validatorService;
            this.dbContext = dbContext;
        }

        public async Task AddSpecification(int productId, int valueId)
        {
            var isProductValid = await validatorService.IsProductValidAsync(productId);
            if (!isProductValid)
            {
                throw new ArgumentException("Invalid Product");
            }
            var isValueIdValid = await validatorService.IsSpecificationValueValidAsync(valueId);
            if (!isValueIdValid)
            {
                throw new ArgumentException("Invalid Value");
            }
            var product = await dbContext.Products.FirstAsync(x => x.Id == productId);
            var productSpecificationValue = new ProductSpecificationValues
            {
                SpecificationValueId = valueId,
            };
            product.Specifications.Add(productSpecificationValue);

            var saveResult = await dbContext.SaveChangesAsync();
        }

        public async Task RemoveSpecification(int productId, int valueId)
        {
            var isProductValid = await validatorService.IsProductValidAsync(productId);
            if (!isProductValid)
            {
                throw new ArgumentException("Invalid Product");
            }
            var isValueIdValid = await validatorService.IsSpecificationValueValidAsync(valueId);
            if (!isValueIdValid)
            {
                throw new ArgumentException("Invalid Value");
            }
            var product = await dbContext.Products.Include(x => x.Specifications).FirstAsync(x => x.Id == productId);
            foreach (var item in product.Specifications)
            {
                if (item.SpecificationValueId == valueId)
                {
                    product.Specifications.Remove(item);
                }
            }
            await dbContext.SaveChangesAsync();
        }

    }
}
