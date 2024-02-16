namespace HardwareStore.App.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using static Constants;

    public class CategoryDataService : ICategoryDataService
    {
        private ApplicationDbContext dbContext;
        private IMapper mapper;


        public CategoryDataService(IMapper mapper, ApplicationDbContext dbContext, IDownloadImageService downloadImageService)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;

        }

        public async Task<ServiceResult> CreateCategory(string name , string imageUrl)
        {

            var serviceResult = new ServiceResult();
            var newCategoryName = name.Trim();

            var categoryExsist = dbContext.Categories.ToList().FirstOrDefault(x => string.Equals(x.Name, newCategoryName, StringComparison.OrdinalIgnoreCase));

            if (categoryExsist != null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryExsist, categoryExsist.Name));
                return serviceResult;
            }

            var newCategory = new Category()
            {
                Name = newCategoryName.ToTitleCase(),
                Url = imageUrl
            };

            dbContext.Categories.Add(newCategory);
            var result = await dbContext.SaveChangesAsync();
            return serviceResult;

        }

        public async Task<ServiceResult> EditCategory(CategoryEditModel model)
        {
            var serviceResult = new ServiceResult();
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (category == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryDosentExsist, model.Name));
                return serviceResult;
            }
            var categoryExist = dbContext.Categories
                .Where(x => x.Id != category.Id).ToList()
                .Any(x => string.Equals(x.Name, model.Name, StringComparison.OrdinalIgnoreCase));
            if (categoryExist)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryExsist, model.Name));
                return serviceResult;
            }

            category.Name = model.Name.ToTitleCase();
            category.FilePath = model.ImageFilePath;
            category.Url = model.ImageUrl;


            await dbContext.SaveChangesAsync();

            return serviceResult;
        }

        public async Task<ServiceResult> CreateSpecification(SpecificationCreateModel model)
        {
            var serviceResult = new ServiceResult();

            var categoryExists = await dbContext.Categories.Include(x => x.Specifications).FirstOrDefaultAsync(x => x.Id == model.CategoryId);
            if (categoryExists == null)
            {
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryDosentExsist));
                serviceResult.Success = false;
                return serviceResult;
            }

            var specificationExsist = categoryExists.Specifications
                .FirstOrDefault(x => String.Equals(x.Name, model.Name, StringComparison.OrdinalIgnoreCase));

            if (specificationExsist != null)
            {
                serviceResult.ErrorMessage
                    .Add(string.Format(ErrorMessages.SpecificationExsist, specificationExsist.Name, categoryExists.Name));
                serviceResult.Success = false;
                return serviceResult;
            }

            var specification = new Specification()
            {
                CategoryId = categoryExists.Id,
                Name = model.Name.ToTitleCase(),
                InfoLevel = model.Essential == true ? "Essential" : "None",
                Filter = model.Filter
            };
            dbContext.Specifications.Add(specification);
            await dbContext.SaveChangesAsync();
            return serviceResult;
        }

        public async Task<ServiceResult> EditSpecification(SpecificationEditModel model)
        {
            var serviceResult = new ServiceResult();
            var category = await dbContext.Categories.Include(x => x.Specifications).FirstOrDefaultAsync(x => x.Id == model.CategoryId);
            if (category == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryDosentExsist));
                return serviceResult;
            }
            var specification = category.Specifications.FirstOrDefault(x => x.Id == model.Id);
            var specificationExsist = category.Specifications.Where(x => x.Id != specification.Id).Any(x => String.Equals(x.Name, model.Name, StringComparison.OrdinalIgnoreCase));
            if (specificationExsist)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.SpecificationExsist, model.Name, category.Name));
                return serviceResult;
            }

            specification.Name = model.Name.ToTitleCase();
            specification.Filter = model.Filter;
            specification.InfoLevel = model.Essential == true ? "Essential" : "None";

            await dbContext.SaveChangesAsync();
            return serviceResult;
        }

        public async Task<ServiceResult> CreateSpecificationValue(SpecificationValueCreateModel model)
        {
            var serviceResult = new ServiceResult();
            var category = await dbContext.Categories.Include(x => x.Specifications).ThenInclude(x => x.Values).FirstOrDefaultAsync(x => x.Id == model.CategoryId);

            if (category == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryDosentExsist));
                return serviceResult;
            }
            var specification = category.Specifications.FirstOrDefault(x => x.Id == model.SpecificationId);
            if (specification == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(ErrorMessages.SpecificationDoesentExsist);
                return serviceResult;
            }
            var valueExsist = specification.Values.FirstOrDefault(x => String.Equals(x.Value, model.Value, StringComparison.OrdinalIgnoreCase));
            if (valueExsist != null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.SpecificationValueExsist, category.Name, specification.Name, model.Value));
                return serviceResult;
            }

            var newValue = new SpecificationValue
            {
                Value = model.Value.ToTitleCase(),
                Metric = model.Metric
            };
            specification.Values.Add(newValue);
            await dbContext.SaveChangesAsync();

            return serviceResult;
        }

        public async Task<ServiceResult> EditSpecificationValue(SpecificationValueEditModel model)
        {
            var serviceResult = new ServiceResult();
            var category = await dbContext.Categories.Include(x => x.Specifications).ThenInclude(x => x.Values).FirstOrDefaultAsync(x => x.Id == model.CategoryId);

            if (category == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryDosentExsist));
                return serviceResult;
            }
            var specification = category.Specifications.FirstOrDefault(x => x.Id == model.SpecificationId);
            if (specification == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(ErrorMessages.SpecificationDoesentExsist);
                return serviceResult;
            }
            var value = specification.Values.FirstOrDefault(x => x.Id == model.ValueId);
            if (value == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add("Invalid Value Id");
                return serviceResult;
            }
            var valueExsist = specification.Values.Where(x => x.Id != value.Id).Any(x => string.Equals(x.Value, model.Value, StringComparison.OrdinalIgnoreCase));
            if (valueExsist)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.SpecificationValueExsist, category.Name, specification.Name, model.Value.ToTitleCase()));
                return serviceResult;
            }
            value.Value = model.Value.ToTitleCase();
            value.Metric = model.Metric;
            await dbContext.SaveChangesAsync();
            return serviceResult;
        }

        public async Task<ICollection<TModel>> GetCategories<TModel>()
        {
            var categories = dbContext.Categories.AsQueryable();
            
            return await categories.ProjectTo<TModel>(mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<ICollection<(string Name, int Id)>> GetCategoriesAsTupleCollectionAsync()
        {

            var categoriesQuery = await dbContext.Categories.Select(x => new
            {
                Name = x.Name,
                Id = x.Id,
            }).ToListAsync();
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
                    CategoryId = x.CategoryId,
                    Values = x.Values.Select(x => new SpecificationValueInfoModel
                    {
                        Id = x.Id,
                        Value = x.Value,
                        Metric = x.Metric
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return specificationInfo;
        }
    }
}
