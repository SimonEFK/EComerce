namespace HardwareStore.App.Services.Data.Products
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Areas.Administration.Models.ProductManagment;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    public class ProductDataService : IProductDataService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDownloadImageService downloadImageService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;


        public ProductDataService(ApplicationDbContext dbContext, IMapper mapper, IDownloadImageService downloadImageService, IWebHostEnvironment env)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.downloadImageService = downloadImageService;
            this.env = env;
        }

        public async Task<TModel?> GetProductById<TModel>(int id)
        {
            var product = await dbContext.Products.Where(p => p.Id == id).ProjectTo<TModel>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return product;
        }

        public async Task<ServiceResult> CreateProduct(CreateProductFormModel productFormModel)
        {
            var serviceResult = new ServiceResult();

            var categoryDb = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == productFormModel.CategoryId);
            var manufacturerDb = await dbContext.Manufacturers.FirstOrDefaultAsync(x => x.Id == productFormModel.ManufacturerId);

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
            if (productFormModel.Specifications.Count < 3)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add("Add Atleast 3 Specifications");
                return serviceResult;
            }
            if (!productFormModel.ImageArray.Any())
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add("Add Atleast 1 Image");
                return serviceResult;
            }

            var product = new Product();
            product.Name = productFormModel.Name.Trim();
            product.NameDetailed = productFormModel.NameDetailed;
            product.Manufacturer = manufacturerDb;
            product.Category = categoryDb;

            foreach (var image in productFormModel.ImageArray)
            {

                var dir = Path.Combine(env.WebRootPath, "Images");
                var url = image;
                var fileName = Guid.NewGuid().ToString();

                //var extension = await downloadImageService.DownloadImageAsync(dir, fileName, new Uri(url));

                var imageDb = new Image()
                {
                    Id = fileName,
                    Url = image,
                    //FilePath = $@"Images/{fileName}{extension}"
                };
                product.Images.Add(imageDb);

            }

            foreach (var item in productFormModel.Specifications)
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

