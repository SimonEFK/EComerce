namespace HardwareStore.App.Services.Data.Products
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    public class ProductDataService : IProductDataService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public int PageSize { get; set; }

        public ProductDataService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<TModel?> GetProductById<TModel>(int id)
        {
            var product = await dbContext.Products.Where(p => p.Id == id).ProjectTo<TModel>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return product;
        }
        public async Task<ICollection<TModel>> GetProducts<TModel>(
            ICollection<int> selectedSpecsIds,
            string? category,
            string? searchString,
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
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return products;
        }

        private static IQueryable<Product> OrderQuery(IQueryable<Product> productsQuery, string sortOrder)
        {
            switch (sortOrder)
            {
                case "newest":
                    productsQuery = productsQuery.OrderBy(x => x.Id).AsQueryable();
                    break;
                case "oldest":
                    productsQuery = productsQuery.OrderByDescending(x => x.Id).AsQueryable();
                    break;
                default:
                    productsQuery = productsQuery.OrderBy(x => x.Id).AsQueryable();
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
