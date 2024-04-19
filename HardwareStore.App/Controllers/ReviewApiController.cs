namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Services.ProductReview;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ReviewApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductReviewService _productReviewService;

        public ReviewApiController(IProductReviewService productReviewService, UserManager<ApplicationUser> userManager)
        {
            _productReviewService = productReviewService;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(ReviewInputModel model)
        {
            var user = await _userManager.GetUserAsync(this.HttpContext.User);
            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                await _productReviewService.CreateReviewAsync(user, model.Content, model.Rating, model.ProductId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
            return Ok();
        }
    }
}
