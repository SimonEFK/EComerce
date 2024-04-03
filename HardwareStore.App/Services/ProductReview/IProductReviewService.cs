namespace HardwareStore.App.Services.ProductReview
{
    using HardwareStore.App.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductReviewService
    {
        Task<ServiceResult> ChangeReviewStatus(int reviewId, bool isApproved);
        Task CreateReview(ApplicationUser user, string content, int? rating, int productId);
        Task<ServiceResult> DeleteReview(int reviewId);
        Task<IEnumerable<ProductReviewDTO>> GetAll(bool includeApproved = false);
        Task<List<ProductReviewDTO>> GetProductReviews(int productId);
    }
}
