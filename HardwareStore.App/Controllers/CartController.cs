namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Models.Cart;
    using HardwareStore.App.Models.Orders;
    using HardwareStore.App.Services.Cart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using HardwareStore.App.Extension;

    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;


        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        public async Task<IActionResult> Index()
        {

            var userId = this.HttpContext.User.Id();

            var userProducts = await _cartService.GetUserCartProductsAsync(userId);

            var cartViewModel = new CartViewModel { CartProducts = userProducts.ToList() };

            var inputModel = new OrderInputModel();
            return View(cartViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItemToCart(int productId)
        {

            var userId = this.HttpContext.User.Id();

            if (userId is null)
            {
                return Redirect($"/Error/ErrorHandler");
            }
            try
            {
                await _cartService.AddProductToCartAsync(userId, productId);

            }
            catch (Exception ex)
            {

                return Redirect($"/Error/ErrorHandler");
            }

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(int productId)
        {
            if (!ModelState.IsValid)
            {
                return Redirect($"/Error/ErrorHandler");
            }
            var userId = this.HttpContext.User.Id();

            try
            {
                await _cartService.RemoveItem(userId, productId);
            }
            catch (Exception ex)
            {
                return Redirect($"/Error/ErrorHandler");
            }

            return RedirectToAction(nameof(Index), "Cart");
        }

    }
}
