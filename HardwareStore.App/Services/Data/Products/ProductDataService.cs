namespace HardwareStore.App.Services.Data.Products
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Models.Product;
    using Microsoft.EntityFrameworkCore;
    using System.Net.NetworkInformation;

    public class ProductDataService : IProductDataService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ProductDataService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ICollection<TModel>> GetProducts<TModel>(string category)
        {

            var productQuery = dbContext.Products.Where(x => x.Category.Name == category).AsQueryable();

            var products = await productQuery
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return products;
        }
    }
}
