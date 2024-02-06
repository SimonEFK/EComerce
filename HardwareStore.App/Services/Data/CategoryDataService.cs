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

        public async Task<CreationStatus> CreateSpecification(SpecificationCreateModel model)
        {
            var status = new CreationStatus();

            var categoryExists = dbContext.Categories.FirstOrDefault(x => x.Id == model.CategoryId);
            if (categoryExists == null)
            {
                status.Messages.Add("Invalid Category");
                status.IsSucssessfull = false;
            }
            var specificationExsist = dbContext.Specifications.FirstOrDefault(x => x.CategoryId == categoryExists.Id && x.Name.ToLower() == model.Name.ToLower());
            if (specificationExsist != null)
            {
                status.Messages.Add($"Specification {model.Name} already exsist in Category \"{categoryExists.Name}\"");
                status.IsSucssessfull = false;
            }
            if (!status.IsSucssessfull)
            {
                return status;
            }
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var specification = new Specification()
            {
                CategoryId = categoryExists.Id,
                Name = textInfo.ToTitleCase(model.Name),
                InfoLevel = model.Essential == true ? "Essential" : "None",
                Filter = model.Filter
            };
            dbContext.Specifications.Add(specification);
            await dbContext.SaveChangesAsync();
            return status;
        }

        public async Task<CreationStatus> EditSpecification(SpecificationEditModel model)
        {
            var creationStatus = new CreationStatus();
            var specification = await dbContext.Specifications.FirstOrDefaultAsync(x => x.Id == model.Id);
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            if (specification != null)
            {
                specification.Name = textInfo.ToTitleCase(model.Name);
                specification.Filter = model.Filter;
                specification.InfoLevel = model.Essential == true ? "Essential" : "None";

            }
            await dbContext.SaveChangesAsync();
            return creationStatus;
        }

        public async Task<CreationStatus> CreateSpecificationValue(SpecificationValueCreateModel model)
        {
            var specification = await dbContext.Specifications.Include(x => x.Values).Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == model.SpecificationId);

            var creationStatus = new CreationStatus();
            if (specification != null)
            {
                if (specification.Values.Any(x => x.Value.ToLower() == model.Value.ToLower()))
                {
                    creationStatus.Messages
                        .Add($"Value:\"{model.Value}\" already exsist in specification {specification.Category.Name}-\"{specification.Name}\"");
                    creationStatus.IsSucssessfull = false;
                    return creationStatus;
                }
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                var newValue = new SpecificationValue
                {
                    Value = textInfo.ToTitleCase(model.Value)
                };
                specification.Values.Add(newValue);
                await dbContext.SaveChangesAsync();
            }
            return creationStatus;
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

        public async Task<SpecificationInfoModel> SpecificationInfo(int specificationId)
        {
            var specificationInfo = await dbContext.Specifications
                .Where(x => x.Id == specificationId)
                .Select(x => new SpecificationInfoModel
                {
                    SpecificationId = x.Id,
                    Name = x.Name,
                    InfoLevel = x.InfoLevel,
                    Filter = x.Filter,
                    Values = x.Values.Select(x => new SpecificationValueInfoModel
                    {
                        Id = x.Id,
                        Value = x.Value
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return specificationInfo;
        }
    }
}
