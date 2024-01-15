namespace HardwareStore.App.Services.Catalog
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Product;
    using Microsoft.EntityFrameworkCore;

    public class CatalogService : ICatalogService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CatalogService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public int PageSize { get; set; }

        public async Task<ICollection<ProductExtendedModel>> GetProducts(
            string? searchString,
            string? category,
            ICollection<int> manufacturerIds,
            ICollection<int> selectedSpecsIds,
            string sortOrder = "newest",
            int pageNumber = 1)
        {

            var productsQuery = dbContext.Products.AsQueryable();

            if (category is not null)
            {
                productsQuery = productsQuery.Where(x => x.Category.Name == category).AsQueryable();
            }
            if (searchString is not null && searchString.Length >= 3)
            {
                productsQuery = productsQuery.Where(x => x.NameDetailed.Contains(searchString) || x.Name.Contains(searchString)).AsQueryable();
            }
            if (manufacturerIds.Count > 0)
            {
                productsQuery = productsQuery.Where(x => manufacturerIds.Contains(x.Manufacturer.Id)).AsQueryable();

            }
            if (selectedSpecsIds.Count > 0)
            {
                productsQuery = productsQuery
                        .Where(product => product.Specifications
                        .Any(specification => selectedSpecsIds
                        .Contains(specification.SpecificationValueId)));
            }

            productsQuery = OrderQuery(productsQuery, sortOrder);
            productsQuery = Pagination(productsQuery, pageNumber);

            var products = await productsQuery
                .ProjectTo<ProductExtendedModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            foreach (var product in products)
            {
                product.Specifications = product.Specifications.DistinctBy(x => x.Name).ToList();
            }

            return products;
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
