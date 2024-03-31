namespace HardwareStore.App.Services.Cart
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using static Constants.Constants;

    public class CartService : ICartService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;
        public CartService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }
        public async Task CreateCartAsync(ApplicationUser applicationUser)
        {
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
        public async Task AddProductToCartAsync(ApplicationUser user, int productId)
        {
            var product = data.Products.FirstOrDefault(x => x.Id == productId);
            var userCart = await GetUserCartAsync(user);
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
                    ProductId = productId
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
        public async Task RemoveItem(ApplicationUser applicationUser, int productId)
        {
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
                data.CartProducts.Remove(productCartEntry);
                await data.SaveChangesAsync();

            }

        }
        public async Task<ICollection<CartProductModel>> GetUserCartProductsAsync(ApplicationUser applicationUser)
        {
            var cart = await data.Carts.FirstOrDefaultAsync(x => x.ApplicationUserId == applicationUser.Id);
            var cartProducts = await data.CartProducts
                .Where(x => x.CartId == cart.Id).ProjectTo<CartProductModel>(mapper.ConfigurationProvider).ToListAsync();            
            return cartProducts;
        }
    }
}
