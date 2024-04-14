namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.ProductCatalog;
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Services.ProductReview;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class ReviewController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductReviewService _productReviewService;

        public ReviewController(UserManager<ApplicationUser> userManager, IProductReviewService productReviewService)
        {
            _userManager = userManager;
            _productReviewService = productReviewService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateReview(ReviewInputModel reviewInputModel)
        //{
        //    var user = await _userManager.GetUserAsync(this.HttpContext.User);
            
        //    await _productReviewService
        //        .CreateReview(user, reviewInputModel.Content, reviewInputModel.Rating, reviewInputModel.ProductId);
        //    return Ok();
        //}

        public async Task<IActionResult> ProductReviews(int productId)
        {
            var productReviews = await _productReviewService.GetProductReviews(productId);
            var productReviewInputModel = new ReviewInputModel();
            var productReviewViewModel = new ProductReviewViewModel
            {
                ProductReviews = productReviews,
                ReviewInputModel = productReviewInputModel
            };

            return PartialView("_ProductReviewsPartial", productReviewViewModel);
        }
    }
}
