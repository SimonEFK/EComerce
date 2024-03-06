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

        public GenerateProductFilterOptionService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public ICollection<string> GenerateSortOrderOptions()
        {
            var sortOrderOptions = new List<string>
            {
                "Newest",
                "Oldest",
                "Rating ASC",
                "Rating DESC"
            };
            return sortOrderOptions;
        }
        public async Task<Dictionary<string, List<SpecificationFilterOption>>> GenerateSpecificationOptions(IQueryable<Product> productQuery)
        {
            var categories = productQuery.Select(x => x.CategoryId).ToHashSet<int>();
            var specifications = await dbContext.Specifications
                .Where(x => categories.Contains((int)x.CategoryId))
                .Where(x => x.Filter == true)
                .ProjectTo<SpecificationFilterOption>(mapper.ConfigurationProvider)
                .ToListAsync();
            var specDictionary = specifications.GroupBy(x => x.CategoryName).ToDictionary(group => group.Key, group => group.ToList());

            return specDictionary;

        }
        public async Task<ICollection<Tuple<string, int, int>>> GenerateManufacturerOptions(IQueryable<Product> productQuery)
        {
            var categories = productQuery.Select(x => x.CategoryId).ToHashSet<int>();

            var manufacturers = await dbContext.Products.Where(x => categories.Contains((int)x.CategoryId))
                .Select(x => x.Manufacturer)
                .Select(x => new Tuple<string, int, int>(x.Name, x.Id, x.Products.Count))
                .ToListAsync();




            return manufacturers.DistinctBy(x => x.Item2).ToList();

        }
    }
}
