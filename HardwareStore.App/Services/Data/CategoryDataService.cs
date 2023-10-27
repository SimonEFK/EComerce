namespace HardwareStore.App.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using Microsoft.EntityFrameworkCore;

    public class CategoryDataService : ICategoryDataService
    {
        private ApplicationDbContext dbContext;
        private IMapper mapper;

        public CategoryDataService(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<ICollection<TModel>> GetCategories<TModel>(bool isEmpty = false)
        {
            var categories = await dbContext.Categories.Where(x => x.Products.Any()).ProjectTo<TModel>(mapper.ConfigurationProvider).ToListAsync();
            return categories;
        }

    }
}
