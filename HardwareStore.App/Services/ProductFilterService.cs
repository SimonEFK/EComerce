namespace HardwareStore.App.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Models.ProductFilter;
    using Microsoft.EntityFrameworkCore;

    public class ProductFilterService : IProductFilterService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ProductFilterService(ApplicationDbContext dbContext, IMapper mapper)
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
            ;
            var specifications = await dbContext.Specifications
                .Where(x => x.Category.Name == category)
                .Where(x => x.Filter == true)
                .ProjectTo<SpecificationFilterOption>(mapper.ConfigurationProvider)
                .ToListAsync();
            return specifications;
            ;
        }
    }
}
