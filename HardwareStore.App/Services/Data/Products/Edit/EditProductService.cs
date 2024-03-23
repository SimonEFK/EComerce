namespace HardwareStore.App.Services.Data.Products.Edit
{
    using AutoMapper;
    using HardwareStore.App.Data;
    using HardwareStore.App.Services.Data.Products.ProductSpecifications;
    using Microsoft.EntityFrameworkCore;

    public class EditProductService : IEditProductService
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IProductSpecificationService productSpecificationService;
        private readonly IMapper mapper;

        public EditProductService(ApplicationDbContext dbContext, IProductSpecificationService productSpecificationService, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.productSpecificationService = productSpecificationService;
            this.mapper = mapper;
        }

        public async Task<ServiceResultGeneric<T>> EditProductAsync<T>(int id, string name, string? nameDetailed, int categoryId, int manufacturerId)
        {
            var result = new ServiceResultGeneric<T>();
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                result.Success = false;
                result.ErrorMessage = $"Invalid Product with Id:\"{id}\"";
                return result;
            }

            product.Name = name;
            product.NameDetailed = nameDetailed;
            product.CategoryId = categoryId;
            product.ManufacturerId = manufacturerId;

            await dbContext.SaveChangesAsync();
            result.Data = mapper.Map<T>(product);
            return result;
        }

        public async Task<ServiceResult> AddImageAsync(int id, string url)
        {
            var result = new ServiceResult();
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                result.Success = false;
                result.ErrorMessage = $"Invalid Product with Id:\"{id}\"";
                return result;
            }
            var newImageId = Guid.NewGuid().ToString();
            var newImage = new App.Data.Models.Image
            {
                Id = newImageId,
                Url = url,
            };
            product.Images.Add(newImage);
            await dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<ServiceResult> RemoveImageAsync(int id, string imageId)
        {
            var result = new ServiceResult();
            var product = dbContext.Products.Include(x => x.Images).FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                result.Success = false;
                result.ErrorMessage = $"Invalid Product with Id:\"{id}\"";
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
