namespace HardwareStore.App.Services.ProductReview
{
    using HardwareStore.App.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductReviewService
    {
        Task<ServiceResult> ChangeReviewStatusAsync(int reviewId, bool isApproved);
        Task CreateReviewAsync(ApplicationUser user, string content, int? rating, int productId);
        Task<ServiceResult> DeleteReviewAsync(int reviewId, bool trueDelete = false);
        Task<ServiceResult> EditReviewAsync(ApplicationUser user, int reviewId, string content, int rating);
        Task<IEnumerable<ProductReviewDTO>> GetAllAsync(bool includeApproved = false);
        Task<List<ProductReviewDTO>> GetProductReviewsAsync(int productId, bool includeNotApproved = false, bool includeDeleted = false);
        Task<IEnumerable<ProductReviewDTO>> GetUserReviewsAsync(string userId, bool includeNotApproved = false);
    }
}
