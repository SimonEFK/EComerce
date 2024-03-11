namespace HardwareStore.App.Services.ProductReview
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProductReviewService : IProductReviewService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public ProductReviewService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateReview(ApplicationUser user, string content, int? rating, int productId)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product == null)
            {
                throw new ArgumentNullException(nameof(productId), "Invalid Product");
            }
            var review = new ProductReview
            {
                ApplicationUser = user,
                Product = product,
                Review = content,
                Rating = rating,
                CreatedOn = DateTime.UtcNow
            };
            dbContext.ProductReviews.Add(review);
            await dbContext.SaveChangesAsync();
        }
        public async Task<List<ProductReviewDTO>> GetProductReviews(int productId)
        {
            var result = await dbContext.ProductReviews.Where(x => x.ProductId == productId).ProjectTo<ProductReviewDTO>(mapper.ConfigurationProvider).ToListAsync();

            return result;
        }
    }
}
