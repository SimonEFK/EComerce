namespace HardwareStore.App.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Models.ProductFilter;
    using Microsoft.EntityFrameworkCore;

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
                "newest",
                "oldest"
            };
            return sortOrderOptions;
        }
        public async Task<ICollection<SpecificationFilterOption>> GenerateSpecificationOptions(string category)
        {

            var specifications = await dbContext.Specifications
                .Where(x => x.Category.Name == category)
                .Where(x => x.Filter == true)
                .ProjectTo<SpecificationFilterOption>(mapper.ConfigurationProvider)
                .ToListAsync();
            return specifications;

        }
        public ICollection<Tuple<string, int>> GenerateManufacturerOptions(string category)
        {


            var manufacturers = dbContext.Products.Where(x => x.Category.Name == category)
                .Select(x => x.Manufacturer)
                .ToList()
                .DistinctBy(x => x.Id)
                .Select(x => new Tuple<string, int>(x.Name, x.Id)).ToList();

            return manufacturers;

        }
    }
}
