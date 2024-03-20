namespace HardwareStore.App.Services.Data.Products.Create
{
    using CommunityToolkit.Diagnostics;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Services.Validation;

    public class CreateProductService : ICreateProductService
    {
        private ApplicationDbContext dbContext;
        private IValidatorService validatorService;
        private Product product;


        public CreateProductService(ApplicationDbContext dbContext, IValidatorService validatorService)
        {
            this.dbContext = dbContext;
            this.validatorService = validatorService;

        }

        public ICreateProductService CreateProduct(string name, string? nameDetailed, int categoryId, int manufacturerId)
        {
            Guard.IsNotWhiteSpace(name);
            Guard.IsNotEmpty(name);
            if (nameDetailed != null)
            {
                Guard.IsNotEmpty(nameDetailed);
                Guard.IsNotWhiteSpace(nameDetailed);
            }
            Task.Run(async () => await validatorService.IsCategoryValidAsync(categoryId)).GetAwaiter().GetResult();
            Task.Run(async () => await validatorService.IsManufacturerValidAsync(manufacturerId)).GetAwaiter().GetResult();

            product = new Product
            {
                Name = name,
                NameDetailed = nameDetailed,
                CategoryId = categoryId,
                ManufacturerId = manufacturerId
            };
            return this;
        }

        public ICreateProductService AddImages(HashSet<string> images)
        {
            foreach (var image in images)
            {
                var id = Guid.NewGuid().ToString();
                //var filePath = $"/Images/{id}";
                product.Images.Add(new Image
                {
                    Id = id,
                    Url = image
                });
            }
            return this;
        }

        public ICreateProductService AddSpecifications(HashSet<int> specificationValueIds)
        {
            foreach (var valueId in specificationValueIds)
            {
                var isValid = Task.Run(async () => await validatorService.IsSpecificationValueValidAsync(valueId)).GetAwaiter().GetResult();
                if (isValid)
                {
                    product.Specifications.Add(new ProductSpecificationValues
                    {
                        SpecificationValueId = valueId,
                    });
                }
            }
            return this;
        }

        public async Task SaveChangesAsync()
        {
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

        }
    }
}
