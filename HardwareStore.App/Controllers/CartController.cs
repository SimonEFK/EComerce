namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Cart;
    using HardwareStore.App.Services.Cart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(this.HttpContext.User);

            var userProducts = await _cartService.GetUserCartProductsAsync(user);
            var cartViewModel = new CartViewModel { CartProducts = userProducts.ToList() };
            return View(cartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToCart(int productId)
        {

            var user = await _userManager.GetUserAsync(this.HttpContext.User);
            if (user is null)
            {
                return BadRequest();
            }
            await _cartService.AddProductToCartAsync(user, productId);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveItem(int Id)
        {
            var user = await _userManager.GetUserAsync(this.HttpContext.User);

            await _cartService.RemoveItem(user, Id);

            return RedirectToAction(nameof(Index), "Cart");
        }


    }
}
