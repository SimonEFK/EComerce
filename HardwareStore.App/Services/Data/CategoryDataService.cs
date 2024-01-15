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
            var categories = dbContext.Categories.AsQueryable();

            if (!isEmpty)
            {
                categories.Where(x => x.Products.Any());
            }

            return await categories
             .ProjectTo<TModel>(mapper.ConfigurationProvider)
             .ToListAsync();

        }

        public ICollection<(string Name, int Id)> GetCategoriesAsTupleCollection()
        {

            var categoriesQuery = dbContext.Categories.Select(x => new
            {
                Name = x.Name,
                Id = x.Id,
            }).ToList();
            var categoriesResult = new List<(string Name, int Id)>();

            foreach (var category in categoriesQuery)
            {
                categoriesResult.Add((Name: category.Name, Id: category.Id));
            }

            return categoriesResult;
        }


        public ICollection<KeyValuePair<string, int>> GetCategorySpecifications(int categoryId)
        {
            var specifications = dbContext.Specifications
                .Where(x => x.Category.Id == categoryId).ToList()
                .Select(x => new KeyValuePair<string, int>(x.Name, x.Id)).ToList();

            return specifications;
        }

        public ICollection<KeyValuePair<string, int>> GetSpecificationValues(int specificationId)
        {
            var specifications = dbContext.SpecificationValues
                .Where(x => x.SpecificationId == specificationId)
                .Select(x => new KeyValuePair<string, int>(x.Value, x.Id))
                .ToList();

            return specifications;
        }
    }
}
