namespace HardwareStore.App.Services.Data.Products
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Services.Data.Products.Create;
    using HardwareStore.App.Services.Data.Products.Edit;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Metadata;

    public class ProductDataService : IProductDataService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;
        private readonly ICreateProductService createProductService;
        private readonly IEditProductService editProductService;


        public ProductDataService(ApplicationDbContext dbContext, IMapper mapper, IWebHostEnvironment env, ICreateProductService createProductService, IEditProductService editProductService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.env = env;
            this.createProductService = createProductService;
            this.editProductService = editProductService;
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

        public async Task<ServiceResult> EditProduct(EditProductDTO editProductDto)
        {
            var serviceResult = new ServiceResult();

            try
            {
                await editProductService.EditProduct(editProductDto.Id, editProductDto.Name, editProductDto.NameDetailed, editProductDto.CategoryId, editProductDto.ManufacturerId);

            }
            catch (Exception ex)
            {
                serviceResult.ErrorMessage.Add(ex.Message);
                serviceResult.Success = false;
                return serviceResult;

            }
            return serviceResult;
        }
    }
}

