namespace HardwareStore.App.Services.Cart
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using static Constants.Constants;

    public class CartService : ICartService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartService(ApplicationDbContext data, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.data = data;
            this.mapper = mapper;
            _userManager = userManager;
        }
        public async Task CreateCartAsync(string applicationUserId)
        {
            var applicationUser = await this._userManager
                .FindByIdAsync(applicationUserId);

            var userCart = await UserCartExsistAsync(applicationUser);
            if (userCart != null)
            {
                throw new ArgumentException($"User with Id:{applicationUser.Id} Already has a cart");
            }
            var cart = new Cart()
            {
                ApplicationUser = applicationUser,
            };
            data.Carts.Add(cart);
            await data.SaveChangesAsync();
        }
        public async Task AddProductToCartAsync(string applicationUserId, int productId)
        {

            var applicationUser = await this._userManager
               .FindByIdAsync(applicationUserId);

            var product = data.Products.FirstOrDefault(x => x.Id == productId);
            var userCart = await GetUserCartAsync(applicationUser);
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ErrorMessages.InvalidProductId, productId));
            }
            var productCartEntry = await data.CartProducts
                .FirstOrDefaultAsync(x => x.CartId == userCart.Id && x.ProductId == productId);
            if (productCartEntry != null)
            {
                productCartEntry.Amount++;
            }
            else
            {
                productCartEntry = new CartProduct()
                {
                    CartId = userCart.Id,
                    ProductId = productId,
                    Amount = 1
                };
                userCart.Products.Add(productCartEntry);
            }
            await data.SaveChangesAsync();
        }
        private async Task<Cart> GetUserCartAsync(ApplicationUser applicationUser)
        {

            var userCart = await UserCartExsistAsync(applicationUser);
            if (userCart == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidUserCart, applicationUser.Id));
            }
            return userCart;
        }
        private async Task<Cart?> UserCartExsistAsync(ApplicationUser applicationUser)
        {
            return await data.Carts
                .FirstOrDefaultAsync(x => x.ApplicationUserId == applicationUser.Id);
        }
        public async Task RemoveItem(string applicationUserId, int productId)
        {
            var applicationUser = await this._userManager.FindByIdAsync(applicationUserId);
            var product = data.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ErrorMessages.InvalidProductId, productId));
            }
            var userCart = await GetUserCartAsync(applicationUser);
            if (userCart is null)
            {
                throw new ArgumentNullException(nameof(userCart), "Invalid User Cart");
            }

            var productCartEntry = await data.CartProducts
                .FirstOrDefaultAsync(x => x.CartId == userCart.Id && x.ProductId == productId);
            if (productCartEntry != null)
            {
                data.CartProducts.Remove(productCartEntry);
                await data.SaveChangesAsync();
            }

        }
        public async Task<ICollection<CartProductModel>> GetUserCartProductsAsync(string applicationUserId)
        {
            var applicationUser = await this._userManager.FindByIdAsync(applicationUserId);
            var cart = await data.Carts.FirstOrDefaultAsync(x => x.ApplicationUserId == applicationUser.Id);
            var cartProducts = await data.CartProducts
                .Where(x => x.CartId == cart.Id).ProjectTo<CartProductModel>(mapper.ConfigurationProvider).ToListAsync();
            return cartProducts;
        }
    }
}
