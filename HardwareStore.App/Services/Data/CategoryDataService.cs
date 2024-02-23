namespace HardwareStore.App.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Services.Models;
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

        public async Task<ServiceResult> CreateCategory(string name, string imageUrl)
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

        public async Task<ServiceResult> EditCategory(int id, string name, string imageUrl, string imageFilePath)
        {
            var serviceResult = new ServiceResult();
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryDosentExsist, name));
                return serviceResult;
            }
            var categoryExist = dbContext.Categories
                .Where(x => x.Id != category.Id).ToList()
                .Any(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
            if (categoryExist)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryExsist, name));
                return serviceResult;
            }

            category.Name = name.ToTitleCase();
            category.FilePath = imageFilePath;
            category.Url = imageUrl;


            await dbContext.SaveChangesAsync();

            return serviceResult;
        }

        public async Task<ServiceResult> CreateSpecification(int categoryId, string name, bool isFilter = false, bool isEssential = false)
        {
            var serviceResult = new ServiceResult();

            var categoryExists = await dbContext.Categories
                .Include(x => x.Specifications).FirstOrDefaultAsync(x => x.Id == categoryId);
            if (categoryExists == null)
            {
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryDosentExsist));
                serviceResult.Success = false;
                return serviceResult;
            }

            var specificationExsist = categoryExists.Specifications
                .FirstOrDefault(x => String.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));

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
                Name = name.ToTitleCase(),
                InfoLevel = isEssential == true ? "Essential" : "None",
                Filter = isFilter
            };
            dbContext.Specifications.Add(specification);
            await dbContext.SaveChangesAsync();
            return serviceResult;
        }

        public async Task<ServiceResult> EditSpecification(
            int categoryId, int id, string name, bool isFilter = false, bool isEssential = false)
        {
            var serviceResult = new ServiceResult();
            var category = await dbContext.Categories.Include(x => x.Specifications).FirstOrDefaultAsync(x => x.Id == categoryId);
            if (category == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryDosentExsist));
                return serviceResult;
            }
            var specification = category.Specifications.FirstOrDefault(x => x.Id == id);
            var specificationExsist = category.Specifications.Where(x => x.Id != specification.Id).Any(x => String.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
            if (specificationExsist)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.SpecificationExsist, name, category.Name));
                return serviceResult;
            }

            specification.Name = name.ToTitleCase();
            specification.Filter = isFilter;
            specification.InfoLevel = isEssential == true ? "Essential" : "None";

            await dbContext.SaveChangesAsync();
            return serviceResult;
        }

        public async Task<ServiceResult> CreateSpecificationValue(int categoryId, int specificationId, string value, string? metric)
        {
            var serviceResult = new ServiceResult();
            var category = await dbContext.Categories.Include(x => x.Specifications).ThenInclude(x => x.Values).FirstOrDefaultAsync(x => x.Id == categoryId);

            if (category == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryDosentExsist));
                return serviceResult;
            }
            var specification = category.Specifications.FirstOrDefault(x => x.Id == specificationId);
            if (specification == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(ErrorMessages.SpecificationDoesentExsist);
                return serviceResult;
            }
            var valueExsist = specification.Values.FirstOrDefault(x => String.Equals(x.Value, value, StringComparison.OrdinalIgnoreCase));
            if (valueExsist != null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.SpecificationValueExsist, category.Name, specification.Name, value));
                return serviceResult;
            }

            var newValue = new SpecificationValue
            {
                Value = value.ToTitleCase(),
                Metric = metric
            };
            specification.Values.Add(newValue);
            await dbContext.SaveChangesAsync();

            return serviceResult;
        }

        public async Task<ServiceResult> EditSpecificationValue(int categoryId, int specificationId, int valueId, string newValue, string? metric)
        {
            var serviceResult = new ServiceResult();
            var category = await dbContext.Categories.Include(x => x.Specifications).ThenInclude(x => x.Values).FirstOrDefaultAsync(x => x.Id == categoryId);

            if (category == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.CategoryDosentExsist));
                return serviceResult;
            }
            var specification = category.Specifications.FirstOrDefault(x => x.Id == specificationId);
            if (specification == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(ErrorMessages.SpecificationDoesentExsist);
                return serviceResult;
            }
            var value = specification.Values.FirstOrDefault(x => x.Id == valueId);
            if (value == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add("Invalid Value Id");
                return serviceResult;
            }
            var valueExsist = specification.Values.Where(x => x.Id != value.Id).Any(x => string.Equals(x.Value, newValue, StringComparison.OrdinalIgnoreCase));
            if (valueExsist)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage.Add(string.Format(ErrorMessages.SpecificationValueExsist, category.Name, specification.Name, newValue.ToTitleCase()));
                return serviceResult;
            }
            value.Value = newValue.ToTitleCase();
            value.Metric = metric;
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

        public async Task<CategoryInfoDTO> CategoryInfo(int categoryId)
        {
            var category = await dbContext.Categories
                .Where(x => x.Id == categoryId)
                .ProjectTo<CategoryInfoDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return category;
        }

        public async Task<SpecificationInfoDTO> SpecificationInfo(int specificationId)
        {
            var specificationInfo = await dbContext.Specifications
                .Where(x => x.Id == specificationId)
                .ProjectTo<SpecificationInfoDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return specificationInfo;
        }
    }
}
