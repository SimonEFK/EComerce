namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Models.UserProfile;
    using HardwareStore.App.Services.ProductReview;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IProductReviewService _productReviewService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProfileController(IProductReviewService productReviewService, UserManager<ApplicationUser> userManager)
        {
            _productReviewService = productReviewService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserReviews()
        {
            var userId = this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Redirect($"/Error/ErrorHandler");
            }
            var userReviews = await _productReviewService.GetUserReviewsAsync(userId, true);

            var viewModel = new UserProfileViewModel { ProductReviews = userReviews };
            return View(viewModel);
        }

        [HttpPost]        
        public async Task<IActionResult> EditReview(ReviewInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/UserProfile/UserReviews");
            }
            var user = await _userManager.GetUserAsync(this.HttpContext.User);

            var result = await _productReviewService
                .EditReviewAsync(user, model.ReviewId.Value,
                model.Content,
                model.Rating.Value);
            if (result.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errorMessage={result.ErrorMessage}");
            }
            return Redirect("/UserProfile/UserReviews");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveReview(int reviewId)
        {
            var result = await _productReviewService.DeleteReviewAsync(reviewId);
            if (result.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errorMessage={result.ErrorMessage}");
            }

            return Redirect("/UserProfile/UserReviews");
        }


        [HttpGet]
        public IActionResult AddAddress()
        {
            var viewModel = new CreateAddressViewModel();
            return View(viewModel);
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public IActionResult AddAddress(CreateAddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }
            return Ok();
        }

    }
}
