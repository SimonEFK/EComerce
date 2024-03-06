namespace HardwareStore.App.Services.ProductReview
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Services.Models;
    using System.Threading.Tasks;

    public interface IProductReviewService
    {
        Task CreateReview(ApplicationUser user, string content, int? rating, int productId);
        Task<List<ProductReviewDTO>> GetProductReviews(int productId);
    }
}
