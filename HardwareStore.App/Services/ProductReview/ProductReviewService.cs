namespace HardwareStore.App.Services.ProductReview
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using static HardwareStore.App.Constants.Constants;

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
            var product = await dbContext.Products.Include(x=>x.ProductReviews).FirstOrDefaultAsync(x => x.Id == productId);
            if (product == null)
            {
                throw new ArgumentNullException(nameof(productId), "Invalid Product");
            }
            if (product.ProductReviews.Any(x => x.ApplicationUserId == user.Id))
            {
                throw new ArgumentException("User already has review for this product");
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

        public async Task<List<ProductReviewDTO>> GetProductReviews(int productId, bool includeNotApproved = false, bool includeDeleted = false)
        {
            var query = dbContext.ProductReviews
                .Where(x => x.ProductId == productId).AsQueryable();
            if (!includeNotApproved)
            {
                query = query.Where(x => x.IsApproved == true);
            }
            if (!includeDeleted)
            {
                query = query.Where(x => x.IsDeleted == false);
            }
            var result = await query
            .ProjectTo<ProductReviewDTO>(mapper.ConfigurationProvider).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<ProductReviewDTO>> GetAll(bool includeNotApproved = false)
        {
            var query = dbContext.ProductReviews.AsQueryable();

            if (!includeNotApproved)
            {
                query = query.Where(x => x.IsApproved == true);
            }

            var reviews = await query
            .ProjectTo<ProductReviewDTO>(mapper.ConfigurationProvider)
            .ToListAsync();
            return reviews;
        }

        public async Task<IEnumerable<ProductReviewDTO>> GetUserReviews(string userId, bool includeNotApproved = false)
        {
            var query = dbContext.ProductReviews.AsQueryable();

            if (!includeNotApproved)
            {
                query = query.Where(x => x.IsApproved == true);
            }
            var userReviews = await query.Where(x => x.ApplicationUserId == userId).ProjectTo<ProductReviewDTO>(mapper.ConfigurationProvider).ToListAsync();

            return userReviews;
        }

        public async Task<ServiceResult> ChangeReviewStatus(int reviewId, bool isApproved)
        {
            var serviceResult = new ServiceResult();

            var review = await dbContext.ProductReviews.FirstOrDefaultAsync(x => x.Id == reviewId);
            if (review == null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = string.Format(ErrorMessages.InvalidReviewId, reviewId);
            }
            review.IsApproved = isApproved;
            await dbContext.SaveChangesAsync();

            return serviceResult;
        }

        public async Task<ServiceResult> DeleteReview(int reviewId, bool trueDelete = false)
        {
            var serviceResult = new ServiceResult();
            var review = await dbContext.ProductReviews.FirstOrDefaultAsync(x => x.Id == reviewId);

            if (review is null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = (string.Format(ErrorMessages.InvalidReviewId, reviewId));
                return serviceResult;
            }

            if (trueDelete == true)
            {
                dbContext.ProductReviews.Remove(review);

            }
            else
            {
                review.IsDeleted = true;
            }

            await dbContext.SaveChangesAsync();
            return serviceResult;
        }

        public async Task<ServiceResult> EditReview(ApplicationUser user, int reviewId, string content, int rating)
        {
            var serviceResult = new ServiceResult();
            var review = await dbContext.ProductReviews.FirstOrDefaultAsync(x => x.Id == reviewId);
            if (review is null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = string.Format(ErrorMessages.InvalidReviewId, reviewId);
                return serviceResult;
            }
            if (review.ApplicationUserId != user.Id)
            {
                serviceResult.Success = false;
                return serviceResult;
            }
            if (review.Review != content)
            {
                review.Review = content;
                review.IsApproved = false;
            }
            review.Rating = rating;
            review.IsDeleted = false;

            await dbContext.SaveChangesAsync();
            return serviceResult;
        }
    }
}
