namespace HardwareStore.App.Services.Catalog
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Services.Models;
    using HardwareStore.App.Services.ProductFiltering;
    using Microsoft.EntityFrameworkCore;

    public class CatalogService : ICatalogService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IGenerateProductFilterOptionService generateProductFilterOptionService;
        private readonly IMapper mapper;

        public CatalogService(ApplicationDbContext dbContext, IMapper mapper, IGenerateProductFilterOptionService generateProductFilterOptionService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.generateProductFilterOptionService = generateProductFilterOptionService;
        }

        public int PageSize { get; set; }

        public async Task<CatalogModel> GetProducts(
            string? searchString,
            int? category,
            ICollection<int> manufacturerIds,
            Dictionary<int, HashSet<int>> selectedSpecsIds,
            string sortOrder = "newest",
            int pageNumber = 1)
        {

            var productsQuery = dbContext.Products.AsQueryable();

            if (searchString is not null && searchString.Length >= 3)
            {
                productsQuery = productsQuery.Where(x => x.NameDetailed.Contains(searchString) || x.Name.Contains(searchString)).AsQueryable();
            }
            if (category is not null)
            {
                productsQuery = productsQuery.Where(x => x.Category.Id == category).AsQueryable();
            }
            if (manufacturerIds.Count > 0)
            {
                productsQuery = productsQuery.Where(x => manufacturerIds.Contains(x.Manufacturer.Id)).AsQueryable();

            }
            if (selectedSpecsIds.Count > 0)
            {
                foreach (var key in selectedSpecsIds)
                {
                    productsQuery = productsQuery
                            .Where(product => product.Specifications.Any(specification => key.Value
                            .Contains(specification.SpecificationValueId)));
                    if (productsQuery.Count() == 0)
                    {
                        break;
                    }
                }
            }

            var catalogModel = new CatalogModel();
            catalogModel
                .SpecificationFilters = await generateProductFilterOptionService
                .GenerateSpecificationOptions(productsQuery);
            catalogModel
                .Manufacturers = await generateProductFilterOptionService
                .GenerateManufacturerOptions(productsQuery);
            catalogModel.SortOrder = generateProductFilterOptionService.GenerateSortOrderOptions();

            productsQuery = OrderQuery(productsQuery, sortOrder);
            productsQuery = Pagination(productsQuery, pageNumber);


            var products = await productsQuery
                .ProjectTo<ProductExtendedModel>(mapper.ConfigurationProvider)
                .ToListAsync();


            foreach (var product in products)
            {
                product.Specifications = product.Specifications.DistinctBy(x => x.Name).ToList();
            }

            catalogModel.Products = products;

            return catalogModel;
        }


        public async Task<ProductDetailedModel> GetProductById(int id)
        {
            var product = await dbContext.Products.Where(p => p.Id == id)
                .ProjectTo<ProductDetailedModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (product is not null)
            {
                product.Specifications = product.Specifications.DistinctBy(x => x.Name).ToList();
            }

            return product;
        }

        public async Task<List<ProductSimplifiedModel>> GetLatestProductsAsync(int count = 4)
        {

            var products = await dbContext.Products.OrderByDescending(x => x.Id).Take(count).ProjectTo<ProductSimplifiedModel>(mapper.ConfigurationProvider).ToListAsync();
            return products;
        }

        private static IQueryable<Product> OrderQuery(IQueryable<Product> productsQuery, string sortOrder)
        {
            switch (sortOrder.ToLower())
            {
                case "newest":
                    productsQuery = productsQuery.OrderByDescending(x => x.Id).AsQueryable();
                    break;
                case "oldest":
                    productsQuery = productsQuery.OrderBy(x => x.Id).AsQueryable();
                    break;
                default:
                    productsQuery = productsQuery.OrderByDescending(x => x.Id).AsQueryable();
                    break;
            }
            return productsQuery;

        }

        private IQueryable<Product> Pagination(IQueryable<Product> productsQuery, int pageNumber)
        {
            var productCount = productsQuery.Count();
            var itemsPerPage = 12;
            var pageSize = (int)Math.Ceiling(productCount / (double)itemsPerPage);
            PageSize = pageSize;

            if (pageNumber > pageSize)
            {
                pageNumber = pageSize;
            }
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }

            var skipAmount = (pageNumber - 1) * itemsPerPage;
            var takeAmount = itemsPerPage;

            return productsQuery
                            .Skip(skipAmount)
                            .Take(takeAmount);
        }
    }
}
