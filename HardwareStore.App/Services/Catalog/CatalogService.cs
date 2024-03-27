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

        private IQueryable<Product> products;

        private int pageCount;

        public int PageCount { get => pageCount; private set => pageCount = value; }

        public CatalogService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.products = dbContext.Products.AsQueryable();
        }

        public ICatalogService GetProducts(string? searchstring)
        {
            if (searchstring != null)
            {
                this.products = dbContext.Products
                    .Where(x => x.NameDetailed.Contains(searchstring) || x.Name.Contains(searchstring)).AsQueryable();
            }

            return this;
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
            var products = await dbContext.Products.OrderByDescending(x => x.Id)
                .Take(count)
                .ProjectTo<ProductSimplifiedModel>(mapper.ConfigurationProvider)
                .ToListAsync();
            return products;
        }

        public ICatalogService ByCategory(int? categoryId)
        {
            if (categoryId != null)
            {
                this.products = products.Where(x => x.CategoryId == categoryId).AsQueryable();
            }
            return this;
        }

        public ICatalogService ByManufacturer(IEnumerable<int> manufacturerIds)
        {
            if (manufacturerIds.Any())
            {
                this.products = products
                    .Where(x => manufacturerIds
                    .Contains(x.Manufacturer.Id))
                    .AsQueryable();

            }
            return this;
        }

        public ICatalogService FilterBySpecification(Dictionary<int, HashSet<int>> selectedSpecsIds)
        {
            if (selectedSpecsIds.Any())
            {
                foreach (var key in selectedSpecsIds)
                {
                    this.products = products
                            .Where(product => product.Specifications.Any(specification => key.Value
                            .Contains(specification.SpecificationValueId)));
                    if (products.Count() == 0)
                    {
                        break;
                    }
                }

            }
            return this;
        }

        public ICatalogService Order(string sortOrder)
        {
            switch (sortOrder.ToLower())
            {
                case "newest":
                    this.products = products.OrderByDescending(x => x.Id).AsQueryable();
                    break;
                case "oldest":
                    this.products = products.OrderBy(x => x.Id).AsQueryable();
                    break;
                case "rating asc":
                    this.products = products.OrderBy(x => x.ProductReviews.Average(x => x.Rating));
                    break;
                case "rating desc":
                    this.products = products.OrderByDescending(x => x.ProductReviews.Average(x => x.Rating));
                    break;
                case "price asc":
                    this.products = products.OrderBy(x => x.Price).ThenBy(x => x.Name);
                    break;
                case "price desc":
                    this.products = products.OrderByDescending(x => x.Price).ThenBy(x => x.Name);
                    break;
                default:
                    this.products = products.OrderByDescending(x => x.Id).AsQueryable();
                    break;
            }
            return this;
        }

        public ICatalogService Pagination(int pageNumber, int itemsPerPage = 12)
        {
            var productCount = this.products.Count();
            this.pageCount = (int)Math.Ceiling(productCount / (double)itemsPerPage);

            if (pageNumber > this.pageCount)
            {
                pageNumber = this.pageCount;
            }

            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }

            var skipAmount = (pageNumber - 1) * itemsPerPage;
            var takeAmount = itemsPerPage;            
            this.products = this.products.Skip(skipAmount).Take(takeAmount);

            return this;
        }
       
        public async Task<List<T>> ToList<T>() where T : class
        {
            var products = await this.products.ProjectTo<T>(mapper.ConfigurationProvider).ToListAsync();
            return products;
        }
    }
}
