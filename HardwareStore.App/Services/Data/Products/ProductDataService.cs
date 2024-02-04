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

        public async Task<CreationStatus> CreateProduct(CreateProductFormModel productFormModel)
        {
            var status = new CreationStatus();

            var categoryDb = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == productFormModel.CategoryId);
            var manufacturerDb = await dbContext.Manufacturers.FirstOrDefaultAsync(x => x.Id == productFormModel.ManufacturerId);

            if (categoryDb == null)
            {
                status.IsSucssessfull = false;
                status.Messages.Add("Category Doesn't Exsist");
            }
            if (manufacturerDb == null)
            {
                status.IsSucssessfull = false;
                status.Messages.Add("Manufacturer Doesn't Exsist");
            }
            if (productFormModel.Specifications.Count < 3)
            {
                status.IsSucssessfull = false;
                status.Messages.Add("Specifications Count too low");
            }
            if (!productFormModel.ImageUrlList.Any())
            {
                status.IsSucssessfull = false;
                status.Messages.Add("not enough Images");
            }

            if (!status.IsSucssessfull)
            {
                return status;
            }
            var product = new Product();
            product.Name = productFormModel.Name;
            product.NameDetailed = productFormModel.NameDetailed;

            product.Manufacturer = manufacturerDb;
            product.Category = categoryDb;

            foreach (var image in productFormModel.ImageUrlList)
            {

                var dir = Path.Combine(env.WebRootPath, "Images");
                var url = image;
                var fileName = Guid.NewGuid().ToString();

                bool isValidUrl = Uri.IsWellFormedUriString(url, UriKind.Absolute);
                if (!isValidUrl)
                {
                    status.Messages.Add($" \"{url}\" is Invalid Url");
                    continue;
                }

                var extension = await downloadImageService.DownloadImageAsync(dir, fileName, new Uri(url));
                if (extension != ".jpg" && extension != ".png")
                {
                    status.Messages.Add($"\"{url}\" has invalid extension");
                    continue;
                }
                var imageDb = new Image()
                {
                    Id = fileName,
                    Url = image,
                    FilePath = $@"Images/{fileName}{extension}"
                };
                product.Images.Add(imageDb);

            }
            if (!product.Images.Any())
            {
                status.IsSucssessfull = false;
                status.Messages.Add("Product has no valid Images");
                return status;
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

            try
            {
                dbContext.Products.Add(product);
                await dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                status.IsSucssessfull = false;
                status.Messages.Add(ex.Message);
                return status;
            }
            status.Id = product.Id;
            return status;
        }
    }
}

