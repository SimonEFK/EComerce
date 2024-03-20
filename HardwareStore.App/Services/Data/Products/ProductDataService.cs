namespace HardwareStore.App.Services.Data.Products
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using Microsoft.EntityFrameworkCore;

    public class ProductDataService : IProductDataService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;
        private readonly ICreateProductService createProductService;


        public ProductDataService(ApplicationDbContext dbContext, IMapper mapper, IWebHostEnvironment env, ICreateProductService createProductService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.env = env;
            this.createProductService = createProductService;
        }

        public async Task<TModel?> GetProductById<TModel>(int id)
        {
            var product = await dbContext.Products.Where(p => p.Id == id).ProjectTo<TModel>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return product;
        }

        public async Task<ServiceResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            var serviceResult = new ServiceResult();

            try
            {
                await this.createProductService
                .CreateProduct(createProductDTO.Name, createProductDTO.NameDetailed, createProductDTO.CategoryId, createProductDTO.ManufacturerId)
                .AddImages(createProductDTO.ImageUrls)
                .AddSpecifications(createProductDTO.Specifications)
                .SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(ex.Message);
                return serviceResult;
            }
            

            return serviceResult;

        }
    }
}

