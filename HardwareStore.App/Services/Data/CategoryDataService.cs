namespace HardwareStore.App.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Areas.Administration.Models;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Services.Data.Products;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    public class CategoryDataService : ICategoryDataService
    {
        private ApplicationDbContext dbContext;
        private IMapper mapper;
        private IUrlValidationService urlValidationService;

        public CategoryDataService(IMapper mapper, ApplicationDbContext dbContext, IDownloadImageService downloadImageService, IUrlValidationService urlValidationService)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.urlValidationService = urlValidationService;
        }


        public async Task<CreationStatus> CreateCategory(CategoryCreateModel model)
        {
            var status = new CreationStatus();
            var newCategoryName = model.Name.Trim().ToLower();
            var categoryExsist = dbContext.Categories.Any(x => x.Name.ToLower() == newCategoryName);

            if (categoryExsist)
            {
                status.IsSucssessfull = false;
                status.Messages.Add($"Category with name {model.Name} already exsist");
            }
            if (!status.IsSucssessfull)
            {
                return status;
            }
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var newCategory = new Category()
            {
                Name = textInfo.ToTitleCase(model.Name),
                Url = model.Image
            };

            dbContext.Categories.Add(newCategory);
            await dbContext.SaveChangesAsync();
            return status;

        }

        public async Task<ICollection<TModel>> GetCategories<TModel>()
        {
            var categories = await dbContext.Categories
             .ProjectTo<TModel>(mapper.ConfigurationProvider)
             .ToListAsync();
            return categories;
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

        public async Task<CategoryInfoModel> CategoryInfo(int categoryId)
        {
            var category = await dbContext.Categories
                .Where(x => x.Id == categoryId)
                .Select(x => new CategoryInfoModel
                {
                    Id = x.Id,
                    CategoryName = x.Name,
                    ImageUrl = x.Url,
                    ImageFilePath = x.FilePath,
                    Specifications = x.Specifications.Select(s => new SpecificationInfoModel
                    {
                        SpecificationId = s.Id,
                        Name = s.Name,
                        InfoLevel = s.InfoLevel,
                        Filter = s.Filter,
                        Values = s.Values.Select(v => new SpecificationValueInfoModel
                        {
                            Id = v.Id,
                            Value = v.Value
                        }).ToList()
                    }).ToList()
                }).FirstOrDefaultAsync();

            return category;
        }

        public async Task EditCategory(int id, string name, string url, bool downloadImage = false)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                if (category.Name.Equals(name))
                {
                    return;
                }
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                category.Name = textInfo.ToTitleCase(name.Trim());

                if (url != null)
                {
                    category.Url = url;
                }

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<CreationStatus> CreateSpecification(int categoryId, SpecificationCreateModel model)
        {
            var status = new CreationStatus();
            var specification = new Specification()
            {
                CategoryId = categoryId,
                Name = model.Name,
                InfoLevel = model.InfoLevel,
                Filter = model.Filter
            };
            dbContext.Specifications.Add(specification);
            await dbContext.SaveChangesAsync();
            return status;
        }
    }
}
