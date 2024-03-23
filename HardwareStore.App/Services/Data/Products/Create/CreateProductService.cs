namespace HardwareStore.App.Services.Data.Products.Create
{
    using AutoMapper;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Services.Validation;

    public class CreateProductService : ICreateProductService
    {
        private ApplicationDbContext dbContext;
        private IValidatorService validatorService;
        private IMapper mapper;
        private Product product;

        public CreateProductService(ApplicationDbContext dbContext, IValidatorService validatorService, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.validatorService = validatorService;
            this.mapper = mapper;
        }

        public ICreateProductService CreateProduct(string name, string? nameDetailed, int categoryId, int manufacturerId)
        {
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

        public async Task<ServiceResultGeneric<T>> SaveChangesAsync<T>()
        {
            var result = new ServiceResultGeneric<T>();
            dbContext.Products.Add(product);
            try
            {
                await dbContext.SaveChangesAsync();
                result.Data = mapper.Map<T>(product);
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result;
            }

        }
    }
}
