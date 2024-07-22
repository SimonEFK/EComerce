namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Extension;
    using HardwareStore.App.Models.ProductCatalog;
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Services.Catalog;
    using HardwareStore.App.Services.ProductReview;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    public class ReviewController : Controller
    {

        private readonly IProductReviewService _productReviewService;
        private readonly ICatalogService catalogService;

        public ReviewController(IProductReviewService productReviewService, ICatalogService catalogService)
        {

            _productReviewService = productReviewService;
            this.catalogService = catalogService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(ReviewInputModel reviewInputModel)
        {
            if (!ModelState.IsValid)
            {
                var product = await catalogService.GetProductById(reviewInputModel.ProductId);
                var productReviews = await _productReviewService.GetProductReviewsAsync(reviewInputModel.ProductId);
                var viewModel = new ComponentDetailViewModel
                {
                    Product = product,
                    ProductReviewViewModel = new ProductReviewViewModel
                    {
                        ProductReviews = productReviews,
                        ReviewInputModel = reviewInputModel
                    }
                };
                return View("/ProductCatalog/ComponentDetail", viewModel);
            }
            var userId = this.HttpContext.User.Id();
            try
            {
                await _productReviewService
                .CreateReviewAsync(userId, reviewInputModel.Content, reviewInputModel.Rating, reviewInputModel.ProductId);
            }
            catch (Exception)
            {

                return Redirect("/Home/Error");
            }

            return Redirect($"/ComponentDetail/{reviewInputModel.ProductId}");
        }

        public async Task<IActionResult> ProductReviews(int productId)
        {
            var productReviews = await _productReviewService.GetProductReviewsAsync(productId);
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