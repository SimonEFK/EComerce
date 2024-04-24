namespace HardwareStore.App.Services.Data.Products.Create
{
    using AutoMapper;
    using CommunityToolkit.Diagnostics;
    using HardwareStore.App.Constants;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Services.Validation;
    using Microsoft.EntityFrameworkCore;
    using System.Text.RegularExpressions;

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

        public ICreateProductService CreateProduct(string name, int categoryId, int manufacturerId, string? nameDetailed = null)
        {

            Guard.IsNotNullOrWhiteSpace(name, nameof(name));
            Guard.IsNotWhiteSpace(name, nameof(name));
            Guard.HasSizeLessThanOrEqualTo(name, ModelConstraints.Product.NameMaxLength);
            if (nameDetailed != null)
            {
                Guard.IsNotNullOrWhiteSpace(nameDetailed, nameof(nameDetailed));
                Guard.IsNotWhiteSpace(nameDetailed, nameof(nameDetailed));
                Guard.HasSizeLessThanOrEqualTo(name, ModelConstraints.Product.NameDetailedMaxLength);
                nameDetailed.Trim();
            }

            var isCategoryValid = Task.Run(async () => await validatorService.IsCategoryValidAsync(categoryId)).GetAwaiter().GetResult();
            if (!isCategoryValid)
            {
                throw new ArgumentException("Invalid Category");
            }
            var isManufacturerValid = Task.Run(async () => await validatorService.IsManufacturerValidAsync(manufacturerId)).GetAwaiter().GetResult();
            if (!isManufacturerValid)
            {
                throw new ArgumentException("Invalid Manufacturer");
            }
            product = new Product
            {
                Name = name.Trim(),
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
                if (!Regex.IsMatch(image, ModelConstraints.Image.ImageRegexPattern))
                {
                    throw new ArgumentException($"\"{image}\" has invalid format");
                }
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
                var productCategoryId = this.product.CategoryId;

                var isValidForThisCategory = Task.Run(async () => await validatorService.IsSpecificationValueValidForCategory(productCategoryId,valueId)).GetAwaiter().GetResult();
                
                if (!isValidForThisCategory)
                {
                    continue;
                }
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


        public ICreateProductService SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException($"{nameof(price)} cant be zero or negative.");
            }
            this.product.Price = price;
            return this;
        }
        public async Task<ServiceResultGeneric<T>> SaveChangesAsync<T>()
        {
            var result = new ServiceResultGeneric<T>();
            try
            {
                dbContext.Products.Add(product);
                await dbContext.SaveChangesAsync();
                result.Data = mapper.Map<T>(product);
                return result;
            }
            catch (DbUpdateException ex)
            {
                result.Success = false;
                result.ErrorMessage = "Failed To Create Product";
                return result;
            }

        }
    }
}
