namespace HardwareStore.App.Services.Data.Products
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;    
    using Microsoft.EntityFrameworkCore;

    public class ProductDataService : IProductDataService
    {
        private readonly ApplicationDbContext dbContext;      
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;


        public ProductDataService(ApplicationDbContext dbContext, IMapper mapper,  IWebHostEnvironment env)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;            
            this.env = env;
        }

        public async Task<TModel?> GetProductById<TModel>(int id)
        {
            var product = await dbContext.Products.Where(p => p.Id == id).ProjectTo<TModel>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return product;
        }

        public async Task<ServiceResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            var serviceResult = new ServiceResult();

            var categoryDb = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == createProductDTO.CategoryId);
            var manufacturerDb = await dbContext.Manufacturers.FirstOrDefaultAsync(x => x.Id == createProductDTO.ManufacturerId);

            if (categoryDb == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add("Category Doesn't Exsist");
                return serviceResult;
            }
            if (manufacturerDb == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add("Manufacturer Doesn't Exsist");
                return serviceResult;
            }
            if (createProductDTO.Specifications.Count < 3)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add("Add Atleast 3 Specifications");
                return serviceResult;
            }
            if (!createProductDTO.ImageUrls.Any())
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add("Add Atleast 1 Image");
                return serviceResult;
            }

            var product = new Product();
            product.Name = createProductDTO.Name.Trim();
            product.NameDetailed = createProductDTO.NameDetailed;
            product.Manufacturer = manufacturerDb;
            product.Category = categoryDb;

            foreach (var image in createProductDTO.ImageUrls)
            {

                var dir = Path.Combine(env.WebRootPath, "Images");
                var url = image;
                var fileName = Guid.NewGuid().ToString();               
                var imageDb = new Image()
                {
                    Id = fileName,
                    Url = image,                    
                };
                product.Images.Add(imageDb);
            }

            foreach (var item in createProductDTO.Specifications)
            {
                var specificationKey = item.Key;

                if (specificationKey == "Part #")
                {
                    foreach (var partNumber in item.Value)
                    {
                        product.PartNumbers.Add(new PartNumber()
                        {
                            Number = partNumber
                        });
                    }
                    continue;
                }

                var values = new List<SpecificationValue>();

                var dbSpecification = dbContext
                    .Specifications
                    .Include(x => x.Values)
                    .FirstOrDefault(x => x.Name == specificationKey && x.Category.Name == categoryDb.Name);
                if (dbSpecification == null)
                {
                    dbSpecification = new Specification()
                    {
                        Name = specificationKey,
                        CategoryId = categoryDb.Id
                    };
                    dbContext.Specifications.Add(dbSpecification);

                }
                foreach (var specValue in item.Value)
                {
                    var dbValue = dbSpecification.Values.FirstOrDefault(x => x.Value == specValue);
                    if (dbValue == null)
                    {
                        dbValue = new SpecificationValue
                        {
                            Value = specValue
                        };
                        dbSpecification.Values.Add(dbValue);
                    }
                    values.Add(dbValue);
                }

                foreach (var value in values)
                {
                    product.Specifications.Add(new ProductSpecificationValues
                    {
                        SpecificationValue = value
                    });

                }

            }

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

            return serviceResult;
        }
    }
}

