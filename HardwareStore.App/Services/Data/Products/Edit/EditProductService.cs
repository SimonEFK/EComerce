namespace HardwareStore.App.Services.Data.Products.Edit
{
    using AutoMapper;
    using CommunityToolkit.Diagnostics;
    using HardwareStore.App.Constants;
    using HardwareStore.App.Data;
    using HardwareStore.App.Services.Data.Products.ProductSpecifications;
    using HardwareStore.App.Services.Validation;
    using Microsoft.EntityFrameworkCore;
    using System.Text.RegularExpressions;
    using static Constants.Constants;

    public class EditProductService : IEditProductService
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IProductSpecificationService productSpecificationService;
        private readonly IMapper mapper;
        private readonly IValidatorService validatorService;

        public EditProductService(ApplicationDbContext dbContext, IProductSpecificationService productSpecificationService, IMapper mapper, IValidatorService validatorService)
        {
            this.dbContext = dbContext;
            this.productSpecificationService = productSpecificationService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        public async Task<ServiceResultGeneric<T>> EditProductAsync<T>(int id, string name, string? nameDetailed, int categoryId, int manufacturerId)
        {

            Guard.IsNotNullOrWhiteSpace(name, nameof(name));
            Guard.IsNotWhiteSpace(name, nameof(name));
            Guard.HasSizeLessThanOrEqualTo(name, ModelConstraints.Product.NameMaxLength);
            if (nameDetailed != null)
            {
                Guard.IsNotNullOrWhiteSpace(nameDetailed, nameof(nameDetailed));
                Guard.IsNotWhiteSpace(nameDetailed, nameof(nameDetailed));
                Guard.HasSizeLessThanOrEqualTo(name, ModelConstraints.Product.NameDetailedMaxLength);
            }

            var isCategoryValid = await validatorService.IsCategoryValidAsync(categoryId);
            if (!isCategoryValid)
            {
                throw new ArgumentException("Invalid Category");
            }
            var isManufacturerValid = await validatorService.IsManufacturerValidAsync(manufacturerId);
            if (!isManufacturerValid)
            {
                throw new ArgumentException("Invalid Manufacturer");
            }
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            var result = new ServiceResultGeneric<T>();

            if (product == null)
            {
                result.Success = false;
                result.ErrorMessage = string.Format(ErrorMessages.InvalidProductId, id);
                return result;
            }

            product.Name = name;
            product.NameDetailed = nameDetailed;
            product.CategoryId = categoryId;
            product.ManufacturerId = manufacturerId;

            try
            {
                await dbContext.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
                result.ErrorMessage = "Failed to edit product";
                return result;
            }
            result.Data = mapper.Map<T>(product);
            return result;
        }

        public async Task<ServiceResult> AddImageAsync(int id, string url)
        {

            if (!Regex.IsMatch(url, ModelConstraints.Image.ImageRegexPattern))
            {
                throw new ArgumentException($"\"{url}\" has invalid format");
            }
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            var result = new ServiceResult();

            if (product == null)
            {
                result.Success = false;
                result.ErrorMessage = string.Format(ErrorMessages.InvalidProductId, id);
                return result;
            }
            var newImageId = Guid.NewGuid().ToString();
            var newImage = new App.Data.Models.Image
            {
                Id = newImageId,
                Url = url,
            };
            product.Images.Add(newImage);

            try
            {
                await dbContext.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
                result.ErrorMessage = "Failed to save image";
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> RemoveImageAsync(int id, string imageId)
        {
            var result = new ServiceResult();
            var product = dbContext.Products.Include(x => x.Images).FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                result.Success = false;
                result.ErrorMessage = string.Format(ErrorMessages.InvalidProductId, id);
                return result;
            }

            var imageToRemove = product.Images.FirstOrDefault(x => x.Id == imageId);
            product.Images.Remove(imageToRemove);
            await dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<ServiceResult> AddSpecificationAsync(int productId, int valueId)
        {
            var result = await this.productSpecificationService.AddSpecificationAsync(productId, valueId);
            return result;
        }

        public async Task<ServiceResult> RemoveSpecificationAsync(int productId, int valueId)
        {
            var result = await this.productSpecificationService.RemoveSpecificationAsync(productId, valueId);
            return result;
        }
    }

}
