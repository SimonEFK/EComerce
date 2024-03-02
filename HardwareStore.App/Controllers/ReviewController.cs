namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Services.ProductReview;
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

        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewInputModel reviewInputModel)
        {
            var user = await _userManager.GetUserAsync(this.HttpContext.User);
            await _productReviewService
                .CreateReview(user, reviewInputModel.Content, reviewInputModel.Rating, reviewInputModel.ProductId);
            return Ok();
        }
    }
}
