namespace HardwareStore.App.Services.Data.Products
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Services.Data.Products.Create;
    using HardwareStore.App.Services.Data.Products.Edit;
    using Microsoft.EntityFrameworkCore;

    public class ProductDataService : IProductDataService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;        
        private readonly ICreateProductService createProductService;
        private readonly IEditProductService editProductService;


        public ProductDataService(ApplicationDbContext dbContext, IMapper mapper, ICreateProductService createProductService, IEditProductService editProductService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;            
            this.createProductService = createProductService;
            this.editProductService = editProductService;
        }

        public async Task<TModel> GetProductById<TModel>(int id)
        {
            var product = await dbContext.Products.Where(p => p.Id == id).ProjectTo<TModel>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return product;
        }

        public async Task<IEnumerable<TModel>> GetAll<TModel>()
        {
            var product = await dbContext.Products.ProjectTo<TModel>(mapper.ConfigurationProvider).ToListAsync();

            return product;
        }

        public async Task<ServiceResultGeneric<T>> CreateProductAsync<T>(CreateProductDTO createProductDTO)
        {            
            var result = await this.createProductService
            .CreateProduct(createProductDTO.Name, createProductDTO.CategoryId, createProductDTO.ManufacturerId, createProductDTO.NameDetailed)
            .AddImages(createProductDTO.ImageUrls)
            .AddSpecifications(createProductDTO.Specifications)
            .SetPrice(createProductDTO.Price)
            .SaveChangesAsync<T>();

            return result;
        }

        public async Task<ServiceResultGeneric<T>> EditProductAsync<T>(EditProductDTO editProductDto)
        {
            var result = await editProductService.EditProductAsync<T>(editProductDto.Id, editProductDto.Name, editProductDto.NameDetailed, editProductDto.CategoryId, editProductDto.ManufacturerId);
            return result;
            
        }

        public async Task<ServiceResult> AddImageAsync(int productId, string imageUrl)
        {
            var result = await this.editProductService.AddImageAsync(productId, imageUrl);
            return result;
        }

        public async Task<ServiceResult> RemoveImageAsync(int productId,string imageId)
        {
            var result = await this.editProductService.RemoveImageAsync(productId, imageId);
            return result;
        }

        public async Task<ServiceResult> AddSpecificationAsync(int productId,int valueId)
        {
            var result = await this.editProductService.AddSpecificationAsync(productId, valueId);
            return result;
        }

        public async Task<ServiceResult> RemoveSpecificationAsync(int productId,int valueId)
        {
            var result = await this.editProductService.RemoveSpecificationAsync(productId, valueId);
            return result;
        }
    }
}

