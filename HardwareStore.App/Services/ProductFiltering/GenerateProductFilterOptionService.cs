namespace HardwareStore.App.Services.ProductFiltering
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.ProductFilter;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class GenerateProductFilterOptionService : IGenerateProductFilterOptionService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private IQueryable<Product> products;


        public GenerateProductFilterOptionService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.products = dbContext.Products.AsQueryable().AsNoTracking();
        }

        public ICollection<string> GenerateSortOrderOptions()
        {
            var sortOrderOptions = new List<string>
            {
                "Newest",
                "Oldest",
                "Rating ASC",
                "Rating DESC",
                "Price ASC",
                "Price DESC"
            };
            return sortOrderOptions;
        }
        public async Task<Dictionary<string, List<SpecificationFilterOption>>> GenerateSpecificationOptions(int? categoryId , string? searchString = null)
        {
            if (searchString != null)
            {
                this.products = dbContext.Products
                    .Where(x => x.NameDetailed.Contains(searchString) || x.Name.Contains(searchString)).AsQueryable();
            }
            if (categoryId != null)
            {
                this.products = products.Where(x => x.CategoryId == categoryId).AsQueryable();

            }

            var categories = this.products.Select(x => x.CategoryId).ToHashSet<int>();
            var specifications = await dbContext.Specifications
                .Where(x => categories.Contains((int)x.CategoryId))
                .Where(x => x.Filter == true)
                .ProjectTo<SpecificationFilterOption>(mapper.ConfigurationProvider)
                .ToListAsync();
            var specDictionary = specifications.GroupBy(x => x.CategoryName).ToDictionary(group => group.Key, group => group.ToList());

            return specDictionary;

        }
        public async Task<ICollection<Tuple<string, int, int>>> GenerateManufacturerOptions(int? categoryId, string? searchString)
        {
            if (searchString != null)
            {
                this.products = dbContext.Products
                    .Where(x => x.NameDetailed.Contains(searchString) || x.Name.Contains(searchString)).AsQueryable();
            }
            if (categoryId != null)
            {
                this.products = products.Where(x => x.CategoryId == categoryId).AsQueryable();
            }

            var categories = this.products.Select(x => x.CategoryId).ToHashSet<int>();
            var manufacturers = await this.products.Where(x => categories.Contains((int)x.CategoryId))
                .Select(x => x.Manufacturer)
                .Select(x => new Tuple<string, int, int>(x.Name, x.Id, x.Products.Count))
                .ToListAsync();

            return manufacturers.DistinctBy(x => x.Item2).ToList();
        }
    }
}
