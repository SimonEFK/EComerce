namespace HardwareStore.App.Services.ProductReview
{
    using HardwareStore.App.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductReviewService
    {
        Task<ServiceResult> ChangeReviewStatus(int reviewId, bool isApproved);
        Task CreateReview(ApplicationUser user, string content, int? rating, int productId);
        Task<ServiceResult> DeleteReview(int reviewId,bool trueDelete = false);
        Task<ServiceResult> EditReview(ApplicationUser user, int reviewId, string content, int rating);
        Task<IEnumerable<ProductReviewDTO>> GetAll(bool includeApproved = false);
        Task<List<ProductReviewDTO>> GetProductReviews(int productId);
        Task<IEnumerable<ProductReviewDTO>> GetUserReviews(string userId, bool includeNotApproved = false);
    }
}
